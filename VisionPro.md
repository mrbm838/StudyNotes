# VisionPro

### 一、Attention

##### 1.模板工具

使用模板工具时，为了==提高分数==，可将计分时考虑砸斑勾选去掉，或者掩膜掉可能出现较大偏差的区域。

区域缩放：指定 PMAlign 执行样板搜索时在 X 、Y方向上使用的缩放值。
				  当在一个零件上匹配到多个模板或识别框位置大小偏差较大时，可尝试减少或关闭区域缩放。

接收阈值：当零件倾斜等原因使得得分低时，可降低接收阈值。

##### 2.高级C#脚本：

在Private Member Variables内声明全局图形变量；
在GroupRun方法内编写逻辑语句；
在ModifyLastRunRecord方法内添加输出到图形。

在QuickBuild应用程序中,有三种类型的脚本:

- ToolGroup 脚本: 在 ToolGroup 中添加脚本，可以控制 ToolGroup的运行行为
- Job 脚本: 作业脚本可以对取像过程进行控制，设置取像参数，控制取像行为，例:设置曝光、频闪、自动对焦等
- ToolBlock 脚本: ToolBlöck 脚本使你可以定制或扩展视觉工具的功能，或者对工具的运行结果进行逻辑判断

##### 3.斑点工具

硬阈值(固定)：定义员工像素值为图像分割点，大于此像素值的为物体像素，小于的则为背景像素；对于处在阈值的像素点则很难判断，容易产生空间量化错误。
硬阈值(相对)：以灰度直方图中某个百分比处的像素为图像分割的阈值。
硬阈值(动态)：根据输入图像直方图自动计算员工合适的分割阈值。

1. 提高斑点的识别度可将分段模式设置为硬阈值(固定)，并降低阈值，减少筛选
2. 清除小面积斑点干扰，除了过滤面积，还可增大连通性的最小面积

##### 4.ToolBlock和ToolGroup对比

①都作为工具的容器，都可以进行嵌套，都支持脚本，封装某个功能。

②脚本的输入输出

ToolBlock简单脚本：

 当输入值改变时，需要点击检查界面终端刷新。

```C#
Outputs.Output = Inputs.Input1 + Inputs.Input2;
```

ToolGroup脚本：

在已经生成过的脚本中，改变在初始化方法中定义的变量，需要删除脚本，生成后再添加变量到初始化方法中。

```C#
// Define output and input
public override void Initialize(CogToolGroup host)
{
    int Output;
    this.toolGroup.DefineScriptTerminal(Output, "Output", false);
    this.toolGroup.DefineScriptTerminal(10, "Input", true);
    toolGroup.DefineScriptTerminal("System.Double", 0, "InputDouble", true);
}
// Operate output and input
public override bool GroupRun(ref stringmessage, ref CogToolResultConstants result)
{
    int temp = (int32)this.toolGroup.GetScriptTerminalData("Input");
    this.toolGroup.SetScriptTermianlData("Output", temp);
}
```

③数据链接方式

ToolBlock提供直观的链接方式。

ToolGroup先通过脚本定义输入输出后才能链接，需要在脚本初始化时定义要链接的变量类型才能链接上。

④获取工具的方法

 ToolBlock
简单脚本：Tools.工具名称

```C#
CogBlobTool blob = (CogBlobTool)Tools.MyBlobTool;
Output.degree = CogMisc.RadToDeg(Tools.CogAngleLineLineTool1.Angle);
```

高级脚本：mToolBlock.Tools[工具名称/索引编号/GUID]（GUID唯一标识）

```C#
CogBlobTool blob = (CogBlobTool)mToolBlock.Tools["myBlobTool"];
				 (CogBlobTool)mToolBlock.Tools[0];
```

ToolGroup（需要引用对应工具的程序集）

toolGroup.Tools[工具名称/索引编号]

```C#
CogBlobTool blob = (CogBlobTool)toolGroup.Tools["myBlobTool"];
				  (CogBlobTool)toolGroup.Tools[0];
```

⑤ToolBlock添加记录

当ToolBlock有图像输入时，可通过CogRecord加入到记录并本地显示。

![图像本地显示](E:\Gitee\Backup\Image\VisionPro\图像本地显示.png)

<details>
    <summary>Show Image</summary>
    <pre><code>
    	CogRectangleAffine rec_Left = new CogRectangleAffine();  
        CogRectangleAffine rec_Right = new CogRectangleAffine();
        CogImage8Grey image;
        //---- GroupRun ----
        rec_Left.SideXLength = 50;
        rec_Left.SideYLength = 50;
        rec_Left.LineWidthInScreenPixels = 2;
        rec_Left.Color = CogColorConstants.DarkGreen;
        rec_Left.CenterX = Convert.ToDouble(mToolBlock.Inputs["Item_0_CenterOfMassX"].Value);
        rec_Left.CenterY = (double) mToolBlock.Inputs["Item_0_CenterOfMassY"].Value;
        rec_Right.SideXLength = 50;
        rec_Right.SideYLength = 50;
        rec_Right.LineWidthInScreenPixels = 2;
        rec_Right.Color = CogColorConstants.Red;
        rec_Right.CenterX = (double) mToolBlock.Inputs["Item_1_CenterOfMassX"].Value;
        rec_Right.CenterY = (double) mToolBlock.Inputs["Item_1_CenterOfMassY"].Value;
        //---- ModifyLastRunRecord ----
        image = mToolBlock.Inputs["InputImage"].Value as CogImage8Grey;
        CogRecord record = new CogRecord("ImageName", image.GetType(), CogRecordUsageConstants.Result, false, image, "note");
        lastRecord.SubRecords.Add(record);
        /**************无用！！!***********
        CogImageConvert convert = mToolBlock.Tools["CogImageConvertTool1"] as CogImageConvert;
        CogRecord test = new CogRecord("TestName", typeof(CogImageConvert), CogRecordUsageConstants.Result, false, convert, "note");
        lastRecord.SubRecords.Add(test);
        **********************************/
            CogCircle circle = new CogCircle();
            circle.CenterX = 200;
            circle.CenterY = 200;
            circle.LineWidthInScreenPixels = 2;
            circle.Color = CogColorConstants.Blue;
            circle.Radius = 200;
            mToolBlock.AddGraphicToRunRecord(circle, lastRecord, "note", string.Empty);
        mToolBlock.AddGraphicToRunRecord(rec_Left, record, "note", string.Empty); // record\lastRecord都可
        mToolBlock.AddGraphicToRunRecord(rec_Right, lastRecord, "CogHistogramTool1.InputImage", string.Empty);
    </code></pre>
</details>

⑥自定义工具(*.vtt)

可将ToolBlock和ToolGroup封装成类似工具箱中的某个工具。

##### 5.常用命名空间

| 类、工具  | 命名空间                   |
| --------- | -------------------------- |
| CogRecord | Cognex.VisionPro.Implement |
| List<T>   | System.Collections.Generic |
|           |                            |
|           |                            |

##### 6.CogFindCircle

①指定期望的圆心坐标

将RunParams.ExpectedCircularArc.CenterX/Y作为输入。

![1-6-1图像](E:\Gitee\Backup\Image\VisionPro\1-6-1图像.png)

②卡尺设置

- 当要找的圆在带有一定厚度的圆环内，可使用边缘对模式，并根据搜索方向设置极性
- 找的圆不理想时，在结果中勾选显示最佳拟合圆，向上调整对比度阈值和过滤一半像素，增加筛选

### 二、Methods

##### 1.CogCreateGraphicLabelTool可用高级C#脚本代替(CogToolBlock)

```C#
CogGraphicLabel label = new CogGraphicLabel();

CogCaliperTool capliper = (CogCaliperTool)mToolBlock.Tools["CogCaliperTool2"];
label.SetXYText(0, -50, "Width:" + capliper.Results[0].Width.ToString("f3"));
label.Font = new Font("宋体", 16);
label.Color = CogColorConstants.Red;

mToolBlock.AddGraphicToRunRecord(label, lastRecord, "CogFixtureTool2.OutputImage", string.Empty);
```

##### 2.CogResultsAnalysisTool可用简单脚本代替(CogToolBlock)

CogResultsAnalysisTool无法创造变量

```C#
Outputs.Output_Total = Inputs.Input_Count_Large + Inputs.Input_Count_Small;
```

##### 3.脚本绘图类

| 图形     | 类名               |
| -------- | ------------------ |
| 圆       | CogCircle          |
| 坐标轴   | CogCoordinateAxes  |
| 椭圆     | CogEllipse         |
| 线段     | CogLineSegment     |
| 点标记   | CogPointMarker     |
| 矩形     | CogRectangle       |
| 仿射矩形 | CogRectangleAffine |
| 多边形   | CogPolygon         |



### 三、Solutions

##### 1.标准零件孔位数量统计

直接使用斑点工具会有较大误差，可多次使用斑点工具在会有孔的区域找出斑点。

##### 2.零件瑕疵检测

对于零件孔缺失或者表面污垢，如果直接使用模板工具进行匹配，根据分数来判断误差较大。

制作模板时，将要对比的区域掩膜掉，再使用直方图工具统计区域内像素灰度值，根据平均值判断是否有瑕疵。

##### 3.零件类型检测

1. 图像内要区分出多种零件，直接制定不同模板进行匹配。
2. 图像内只有一种零件，但不同图片内零件不同
   可以先找出所有零件的共同点，制定模板识别出零件，用于==判断零件的有无==；再对不同零件制定不同模板。也可直接使用模板匹配。

##### 4.多零件标注

①使用CogRecord为CogPMAlignTool1的InputImage创建图层

![3-4-1图像](E:\Gitee\Backup\Image\VisionPro\3-4-1图像.png)

```C#
// Variables
List<CogGraphicLabel> listLabel = new List<CogGraphicLabel>();
CogPMAlignTool pm;
// GroupRun
listLabel.Clear();
pm = (CogPMAlignTool) mToolBlock.Tools[1];//["CogPMAlignTool1"];
for(int i = 0; i < pm.Results.Count; i++)
{
    CogGraphicLabel label = new CogGraphicLabel();
    label.SetXYText(pm.Results[i].GetPose().TranslationX,
                    pm.Results[i].GetPose().TranslationY,
                    "分数：" + pm.Results[i].Score.ToString("f3"));
    label.Font = new Font("宋体", 8);
    listLabel.Add(label);
}
// ModifyLastRunRecord
CogImage8Grey image = (CogImage8Grey)pm.InputImage;
CogRecord record = new CogRecord("Key", image.GetType(), CogRecordUsageConstants.Result, false, image, "CogPMAlignTool1.InputImage");
lastRecord.SubRecords.Add(record);

foreach(CogGraphicLabel t in listLabel)
{
    mToolBlock.AddGraphicToRunRecord(t, lastRecord, "CogImageFileTool1.OutputImage", "annotation");
    mToolBlock.AddGraphicToRunRecord(t, lastRecord, "CogPMAlignTool1.InputImage", "annotation");
}
```

②使用CogGraphicCollection将多钟多个图形或文本输出到图像，使用脚本给工具输入值。

![3-4-2图像](E:\Gitee\Backup\Image\VisionPro\3-4-2图像.png)

```C#
// Variables
CogGraphicCollection list = new CogGraphicCollection();
CogPMAlignTool pmAlign;
// GroupRun
list.Clear();
pmAlign = mToolBlock.Tools["CogPMAlignTool1"] as CogPMAlignTool;
CogFindCircleTool findCircle = mToolBlock.Tools["CogFindCircleTool1"] as CogFindCircleTool;
foreach(CogPMAlignResult pmResult in pmAlign.Results)
{
    //findCircle.InputImage = ((CogImageFileTool)mToolBlock.Tools["CogImageFileTool5"]).OutputImage as CogImage8Grey;
    findCircle.RunParams.ExpectedCircularArc.CenterX = pmResult.GetPose().TranslationX;
    findCircle.RunParams.ExpectedCircularArc.CenterY = pmResult.GetPose().TranslationY;
    findCircle.Run();
    CogCircle circle = new CogCircle();
    circle.CenterX = findCircle.Results.GetCircle().CenterX;
    circle.CenterY = findCircle.Results.GetCircle().CenterY;
    circle.Radius = findCircle.Results.GetCircle().Radius;
    list.Add(circle);
    CogGraphicLabel label = new CogGraphicLabel();
    label.SetXYText(pmResult.GetPose().TranslationX, pmResult.GetPose().TranslationY, "半径：" + findCircle.Results.GetCircle().Radius);
    list.Add(label);
}
// ModifyLastRunRecord
CogImage8Grey image = pmAlign.InputImage as CogImage8Grey;
CogRecord record = new CogRecord("Key", image.GetType(), CogRecordUsageConstants.Result, false, image, "CogPMAlignTool1.InputImage");
lastRecord.SubRecords.Add(record);
foreach(ICogGraphic item in list)
{
    mToolBlock.AddGraphicToRunRecord(item, lastRecord, "CogPMAlignTool1.InputImage", "anno");
}
```

<Details>
    <summary>No use CogGraphicCollection</summary>
    <pre><code>
    //------------Variable-----------
    List<CogCircle> listCircle = new List<CogCircle>();
  	List<CogGraphicLabel> listLabel = new List<CogGraphicLabel>();
    //------------GroupRun-----------
  	listCircle.Clear();
    listLabel.Clear();
    pmAlign = mToolBlock.Tools["CogPMAlignTool1"] as CogPMAlignTool;
    CogFindCircleTool findCircle = mToolBlock.Tools["CogFindCircleTool1"] as CogFindCircleTool;
    foreach(CogPMAlignResult pmResult in pmAlign.Results)
    {
      findCircle.InputImage = ((CogImageFileTool) mToolBlock.Tools["CogImageFileTool5"]).OutputImage as CogImage8Grey;
      findCircle.RunParams.ExpectedCircularArc.CenterX = pmResult.GetPose().TranslationX;
      findCircle.RunParams.ExpectedCircularArc.CenterY = pmResult.GetPose().TranslationY;
      findCircle.Run();
      CogCircle circle = new CogCircle();
      circle.CenterX = findCircle.Results.GetCircle().CenterX;
      circle.CenterY = findCircle.Results.GetCircle().CenterY;
      circle.Radius = findCircle.Results.GetCircle().Radius;
      listCircle.Add(circle);
      CogGraphicLabel label = new CogGraphicLabel();
      label.SetXYText(pmResult.GetPose().TranslationX, pmResult.GetPose().TranslationY, "半径：" + findCircle.Results.GetCircle().Radius);
      listLabel.Add(label);
    }
    //------------ModifyLastRunRecord-----------
    CogImage8Grey image = pmAlign.InputImage as CogImage8Grey;
    CogRecord record = new CogRecord("Key", image.GetType(), CogRecordUsageConstants.Result, false, image, "CogPMAlignTool1.InputImage");
    lastRecord.SubRecords.Add(record);    
    foreach(CogCircle circle in listCircle)
    {
      mToolBlock.AddGraphicToRunRecord(circle, lastRecord, "CogPMAlignTool1.InputImage", "anno");
    }
    foreach(CogGraphicLabel label in listLabel)
    {
      mToolBlock.AddGraphicToRunRecord(label, lastRecord, "CogPMAlignTool1.InputImage", "anno");
    }
  	</code></pre>
</details>
③CogCaliperTool动态调整位置

![3-4-3图像](E:\Gitee\Backup\Image\VisionPro\3-4-3图像.png)

```C#
//--------------Variable----------------
List<CogGraphicLabel>  labels = new List<CogGraphicLabel>();
//--------------GroupRun----------------
//2.获取斑点信息 
CogBlobTool  blobTool =mToolBlock.Tools["CogBlobTool1"]  as  CogBlobTool;
//斑点集合
//CogBlobResultCollection  blobResults =blobTool.Results.GetBlobs()  as CogBlobResultCollection;
//获取卡尺工具
CogCaliperTool  caliperTool =mToolBlock.Tools["CogCaliperTool1"]  as  CogCaliperTool;  //获取卡尺工具
//设置卡尺的中心点 之前需要获取区域信息 
//CogRectangleAffine   caliperRegion =caliperTool.Region  as CogRectangleAffine; //仿射矩形  caliperRegion 卡尺的区域

labels.Clear();//清空列表

foreach(CogBlobResult  blob in  blobTool.Results.GetBlobs()) // blobResults
{
    //caliperRegion.CenterX = blob.CenterOfMassX;      //斑点的质心
    //caliperRegion.CenterY = blob.CenterOfMassY;
    caliperTool.Region.CenterX = blob.CenterOfMassX;
    caliperTool.Region.CenterY = blob.CenterOfMassY;
    //运行卡尺
    mToolBlock.RunTool(caliperTool, ref message, ref result);  //运行卡尺工具  ***
    CogGraphicLabel myLabel = new CogGraphicLabel();//定义一个图形标签
    if( caliperTool.Results.Count>0 )
    {
        myLabel.SetXYText(blob.CenterOfMassX,blob.CenterOfMassY ,"Good");
        myLabel.Color = CogColorConstants.Green;
    }
    else
    {
        myLabel.SetXYText(blob.CenterOfMassX,blob.CenterOfMassY ,"Bad");
        myLabel.Color = CogColorConstants.Red;
    } 
    labels.Add(myLabel); //添加到列表当中 
} 
//--------------ModifyLastRunRecord----------------
foreach(CogGraphicLabel  label  in  labels )
{
    mToolBlock.AddGraphicToRunRecord( label, lastRecord,"CogBlobTool1.InputImage","" );
} 
```

