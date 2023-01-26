# PF

## 控件部分

### 一、基本控件

##### 1.标签

* 单标签格式和双标签格式

  双标签可嵌入其它标签

  ```xaml
  <Button/>
  <Button></Button>
  ```

* 根标签
  <Windows>或者<Page>

  根标签下只有一个二级标签<Grid>

##### 2.控件分类

* 内容控件、文本控件、条目控件、布局控件、其它控件

* | 内容控件（System.Windows.Controls.ContentControl） |                          |
  | -------------------------------------------------- | ------------------------ |
  | System.Windows.Controls.Label                      |                          |
  | System.Windows.Controls.TextBlock                  | 继承自FrameworkElement类 |
  | System.Windows.Controls.Button                     |                          |
  | System.Windows.Controls.Border                     | 继承自Decorator类        |
  | System.Windows.Controls.RadioButton                |                          |
  | System.Windows.Controls.CheckBox                   |                          |
  | System.Windows.Controls.ToolTip                    |                          |
  | System.Windows.Controls.GroupBox                   |                          |
  | System.Windows.Controls.Expander                   |                          |
  | System.Windows.Controls.Frame                      |                          |

* | **文本控件** **（System.Windows.Controls.TextBoxBase）** |
  | -------------------------------------------------------- |
  | System.Windows.Controls.TextBox                          |
  | System.Windows.Controls.RichTextBox                      |

* | 条目控件(System.Windows.Controls.ItemsControl) |
  | ---------------------------------------------- |
  | System.Windows.Controls.ComboBox               |
  | System.Windows.Controls.Menu                   |
  | System.Windows.Controls.ContextMenu            |
  | System.Windows.Controls.TabControl             |
  | System.Windows.Controls.ToolBar                |
  | System.Windows.Controls.ToolBarTray            |
  | System.Windows.Controls.ListBox                |
  | System.Windows.Controls.DataGrid               |
  | System.Windows.Controls.TreeView               |

* | 布局控件(System.Windows.Controls.Panel) |
  | --------------------------------------- |
  | System.Windows.Controls.Grid            |
  | System.Windows.Controls.StackPanel      |
  | System.Windows.Controls.DockPanel       |
  | System.Windows.Controls.WrapPanel       |
  | System.Windows.Controls.Canvas          |

##### 2.控件属性

对象：System.Windows.FrameworkElement

| 属性名              | 对象类型            | 作用                                                         |
| ------------------- | ------------------- | ------------------------------------------------------------ |
| Width               | double              | 获取或设置元素的宽度                                         |
| Height              | double              | 获取或设置元素的高度                                         |
| ActualWidth         | double              | 获取此元素呈现的宽度                                         |
| ActualHeight        | double              | 获取此元素呈现的高度                                         |
| Name                | string              | 获取或设置元素的标识名称                                     |
| Style               | Style               | 获取或设置元素呈现时所用的样式                               |
| Margin              | Thickness           | 获取或设置元素的外边距                                       |
| Padding             | Thickness           | 获取或设置元素的内边距                                       |
| HorizontalAlignment | HorizontalAlignment | 获取或设置在父元素中此元素的水平对齐特征                     |
| VerticalAlignment   | VerticalAlignment   | 获取或设置在父元素中此元素的垂直对齐特征                     |
| FocusVisualStyle    | Style               | 获取或设置一个属性允许自定义此元素在捕获<br />到键盘焦点时应用到此元素的样式特征 |
| FlowDirection       | FlowDirection       | 获取或设置文本和其它UI元素在任何控制其布局<br />父元素中流道的方向 |
| DataContent         | object              | 获取或设置元素参与数据绑定时的数据上下文                     |
| Resources           | ResourceDictionary  | 获取或设置本地定义的资源字典                                 |

##### 3.控件的方法

| 方法名        | 参数                                      | 作用                                           |
| ------------- | ----------------------------------------- | ---------------------------------------------- |
| BringIntoView | 可含：targetRectangle(指定视图元素的大小) | 尝试将此元素放入视图，它包含在任何可滚动区域内 |
| FindName      | string name:所请求元素的名称              | 查找具有提供标识符名的元素                     |
| FindResource  | object resourceKey:所请求的资源键标识符   | 搜索具有指定键的资源，如果找不到则引发异常     |

##### 4.控件的事件

| 事件名    | 作用                                       |
| --------- | ------------------------------------------ |
| Loaded    | 对元素进行布局、呈现或其交互时发生         |
| KeyDown   | 当焦点在此元素上时按下某个键后发生         |
| GotFocus  | 当此元素获得逻辑焦点时发生                 |
| MouseDown | 当按下任意鼠标按钮时发生                   |
| MouseMove | 当鼠标指针位于此元素上且移动鼠标指针时发生 |
| Click     | 当点击控件时发生                           |

### 二、内容控件

##### 1.Label

```xaml
<Label Width="100" Height="30" Content="I am label control"
       HorizontalAlignment="Left" VerticalAlignment="Top"
       Margin="5,10" FontSize="20" Foreground="Blue"/>
```

##### 2.TextBlock

显示少量内容的轻型控件，Text的内容和文本内容都回按顺序显示。
`<LineBreak/>`换行标签

```xaml
<TextBlock
           Text="I am TextBlock control" FontSize="30" FontWeight="Bold" FontFamily="宋体"
           VerticalAlignment="Top" Background="Wheat" TextAlignment="Center" Height="149" Grid.RowSpan="2">
    I am text line one <LineBreak/>
    I am text line two <LineBreak/>
    I am text line three <LineBreak/>
</TextBlock>
```

##### 3.Button

`BorderBrush="Transparent"` 使得按钮没有边框

```xaml
<Button Background="Yellow" Width="50" Height="20"
        HorizontalAlignment="Stretch" VerticalAlignment="Top"
        Content="I am button control" BorderBrush="Transparent"
        Click="Button_Click"/>
```

##### 4.Border

在另一个元素四周绘制边框和背景，且只能一个孩子。类似不能包含多个标签的情况下，需要添加Grid之类的布局控件才能有多个孩子
`CornerRadius` 设置弧度

```xaml
<Border Width="200" Height="200" Background="Blue" BorderBrush="Red" BorderThickness="1,1,2,1" CornerRadius="15">
    <Label Foreground="White" Background="Transparent" FontSize="25" Content="safdad" Margin="8,95,10,62"/>
    <Button Background="Yellow" Width="20" Height="20" HorizontalAlignment="Stretch" VerticalAlignment="Top" />
</Border>
```

##### 5.RadioButton

`VerticalContentAlignment="Center"` 使文本居中
**处于同一个`Grid`标签里或者`GroupName`标签值相同的单选框为一组**

```xaml
<RadioButton Content="I am RadioButton control" FontSize="8"
             Foreground="Blue" VerticalAlignment="Bottom"
             VerticalContentAlignment="Center"/>
```

##### 6.CheckBox

```xaml
<CheckBox VerticalAlignment="Bottom" Content="Check one" IsChecked="{x:Null}" Margin="10, 0"/>
<CheckBox VerticalAlignment="Bottom" Content="Check two" IsChecked="False" Margin="10, 20"/>
<CheckBox VerticalAlignment="Bottom" Content="Check three" IsChecked="True" Margin="10, 40"/>
<Button Width="70" VerticalAlignment="Bottom" Margin="50, 0" Click="Button_Click" Content="GetContent"/>
```

```C#
private void Button_Click(object sender, RoutedEventArgs e)
{
    UIElementCollection children = grid.Children;
    string str = "my choises are: ";
    foreach (UIElement item in children)
    {
        if (item is CheckBox && (item as CheckBox).IsChecked == true)
        {
        	str += (item as CheckBox).Content + ";";
        }
    }
    MessageBox.Show(str);
}
```

##### 7.ToolTip

ToolTip作为某个控件的属性用于显示提示信息，前提是该控件继承了FrameworkElement，也可在该控件内单独作一个标签

```Xaml
<TextBox FontSize="50">
    TextBox for ToolTip
    <TextBox.ToolTip>
        <ToolTip>Here tooltip info</ToolTip>
        <!--<TextBlock>Here tooltip info</TextBlock>-->
    </TextBox.ToolTip>
</TextBox>
```

##### 8.GroupBox

```xaml
<GroupBox Header="Groupbox header">
    <Grid>
        <TextBlock>
            asdf dsad <LineBreak/>
            sdafa
        </TextBlock>
        <CheckBox Margin="0,40">check me</CheckBox>
    </Grid>
</GroupBox>

<Grid>
	<GroupBox Template="{StaticResource myGroupBox}"/>
</Grid>
```

##### 9.Expander

用于折叠内容并且显示标题
`IsExpanded`和`ExpandDirection`表示是否展开和展开方向

```xaml
<Expander Header="I am expander control" FontSize="20"
          Width="300" Height="100" BorderThickness="2"
          BorderBrush="Green" IsExpanded="True"
          ExpandDirection="Left">
    <StackPanel>
        <CheckBox VerticalContentAlignment="Center" FontSize="18" Content="C#"/>
        <CheckBox VerticalContentAlignment="Center" FontSize="18" Content="C++"/>
    </StackPanel>
</Expander>
```

##### 10.Frame

用于导航重定向，`NavigationUIVisibility="Visble"`显示后退前进按钮

```xaml
<!-- To net page -->
<Frame Name="frame" Source="http:\\www.baidu.com"
       VerticalAlignment="Top" Width="300" Height="200"
       Margin="0,10" NavigationUIVisibility="Visible"/>

<!-- To custom page -->
<Frame Name="framePage" Source="Page1.xaml"
       VerticalAlignment="Bottom" Width="300" Height="200"
       Margin="0,10" NavigationUIVisibility="Visible"/>
```

```C#
// Redirect by source
frame.Source = new Uri("https://www.bilibili.com");

// Redirect by navigate
frame.Navigate(new Uri("https://www.bilibili.com", UriKind.Absolute));
Page1 myPage = new Page1();
frame.Navigate(myPage);
```

传参的重定向

* 在`Navigate()`方法内传参

  ```C#
  Page1 myPage = new Page1();
  frame.Navigate(myPage, "The parameter");
  ```

  接收参数

  ```xaml
  <Frame Name="frame" Source="http:\\www.baidu.com"
         VerticalAlignment="Top" Width="300" Height="200"
         Margin="0,10" NavigationUIVisibility="Visible"
         LoadCompleted="frame_LoadCompleted"/>
  ```

  ```C#
  private void frame_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
  {
      object param = e.ExtraData;
  }
  ```

* 在Page1内传参

  ```C#
  Page1 myPage = new Page1("The parameter");
  frame.Navigate(myPage);
  ```

  ```C#
  private string _param;
  
  public Page1()
  {
      InitializeComponent();
  }
  
  public Page1(string param) : this()
  {
      _param = param;
  }
  ```

### 三、文本控件

##### 1.TextBox

用于显示或编辑无格式文本，`SelectionBrush`选定文本的颜色

```xaml
<TextBox Text="I am TextBox control" FontSize="40"
                 Width="500" Height="60" BorderThickness="0"
                 SelectionBrush="Orange"/>
```

##### 2.RichTextBox

对`FlowDocument`对象进行操作的丰富编辑的控件

```xaml
<RichTextBox>
    <FlowDocument>
        <Paragraph FontSize="20" TextIndent="20">
            Paragraph1
        </Paragraph>
        <Paragraph>
            <Run FontSize="20">Paragraph2</Run>
            <LineBreak/>
            <Label>this is label</Label>
        </Paragraph>
        <BlockUIContainer>
            <StackPanel>
                <Label HorizontalAlignment="Left" Width="100">this is label too</Label>
                <Button HorizontalAlignment="Left" Width="100">this is button</Button>
            </StackPanel>
        </BlockUIContainer>
        <!-- Simulation formula -->
        <Paragraph FontSize="50">
            <Run>X</Run>
            <InlineUIContainer>
                <TextBlock Margin="-10,-30" FontSize="30">4</TextBlock>
            </InlineUIContainer>
            <Run>+</Run>
            <Run>Y</Run>
            <InlineUIContainer>
                <TextBlock Margin="-10,-30" FontSize="30">4</TextBlock>
            </InlineUIContainer>
        </Paragraph>
        <!-- Hyperlink -->
        <Paragraph>
            <Hyperlink NavigateUri="http://www.baidu.com">
                Baidu
            </Hyperlink>
        </Paragraph>
    </FlowDocument>
</RichTextBox>
```

### 四、条目控件

##### 1.ComboBox

* 使用静态资源

  ```xaml
  xmlns:c="clr-namespace:entity"
  
  <StackPanel Grid.Column="0" Grid.Row="8" Width="200">
      <StackPanel.Resources>
          <c:VacationSpots x:Key="myDataSource"/>
      </StackPanel.Resources>
      <ComboBox Name="combo" ItemsSource="{StaticResource myDataSource}"
                Text="The cities" IsEditable="True"/>
  
      <TextBlock Text="{Binding ElementName=combo, Path=SelectedItem}"/>
  </StackPanel>
  ```

  ```C#
  public class VacationSpots : ObservableCollection<string>
  {
      public VacationSpots()
      {
          Add("spain");
          Add("france");
          Add("peru");
          Add("mexico");
          Add("italy");
      }
  }
  ```

* 在xaml内添加

  ```xaml
  <ComboBox Name="cb" Text="city" IsReadOnly="True"
            Width="100" Height="30">
      <ComboBoxItem>choise1</ComboBoxItem>
      <ComboBoxItem>choise2</ComboBoxItem>
      <Label>label</Label>
  </ComboBox>
  ```
  
* 在代码内添加

  ```C#
  // using items
  cooboo.Items.Add("C#");
  cooboo.Items.Add("C++");
  // using DataContext
  // Need add ItemsSource="{Binding}"
  List<ClassInfo> list = new List<ClassInfo>();
  list.Add(new ClassInfo() { ClassName = "grade one", Code = "101" });
  list.Add(new ClassInfo() { ClassName = "grade two", Code = "201" });
  list.Add(new ClassInfo() { ClassName = "grade three", Code = "301" });
  cooboo.DataContext = list;
  cooboo.DisplayMemberPath = "ClassName";
  cooboo.SelectedValuePath = "Code";
  // using ItemsSource
  cooboo.ItemsSource = list;
  cooboo.DisplayMemberPath = "ClassName";
  cooboo.SelectedValuePath = "Code";
  ```

  当对数据源进行添加删除等操作时，需要将数据源置空再赋值

  ```C#
  list.RemoveAt(0);
  cooboo.ItemsSource = null;
  cooboo.ItemsSource = list;
  ```

##### 2.Menu

```xaml
<!--Define a route-->
<Window.Resources>
    <RoutedUICommand x:Key="cmd"/>
</Window.Resources>
<!--Binding by command-->
<Window.CommandBindings>
    <CommandBinding Command="{StaticResource cmd}" Executed="CommandBinding_Executed"/>
</Window.CommandBindings>
<!--Binding by input-->
<Window.InputBindings>
    <MouseBinding></MouseBinding>
    <KeyBinding Command="{StaticResource cmd}" Gesture="Ctrl+0"></KeyBinding>
</Window.InputBindings>
<Grid>
    <Menu Height="25" VerticalAlignment="Top">
        <MenuItem Header="item_one" Height="20" Margin="0,2"
                  Command="{StaticResource cmd}"/>
        <MenuItem Header="item_one" Height="20" Margin="0,2"/>
        <MenuItem Header="item_one" Height="20" Margin="0,2">
            subitem_zero
            <MenuItem Header="subitem_one" Height="15"/>
            <MenuItem Header="subitem_two" Height="15" InputGestureText="Ctrl+0"/>
        </MenuItem>
    </Menu>
</Grid>
```

```C#
private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
{
    MessageBox.Show("Execute function");
}
```

动态加载数据

```xaml
<Menu Name="menu1" VerticalAlignment="Top" Height="30" Background="Teal"
      ItemsSource="{Binding}">  
    <Menu.ItemContainerStyle>
        <Style TargetType="{x:Type MenuItem}">
            <Setter Property="Command" Value="{Binding ICommand}"></Setter>
        </Style>
    </Menu.ItemContainerStyle>
    <Menu.ItemTemplate>
        <HierarchicalDataTemplate  DataType="{x:Type et:MenuInfo}" ItemsSource="{Binding SubMenus}">
            <TextBlock   Text="{Binding MenuName}"></TextBlock>
        </HierarchicalDataTemplate>
    </Menu.ItemTemplate>
</Menu>
```

```C#
public class MenuInfo
{
    /// <summary>
    /// 菜单名称
    /// </summary>
    public string MenuName { get; set; }

    /// <summary>
    /// 子菜单
    /// </summary>
    public List<MenuInfo> SubMenus { get; set; }


    /// <summary>
    /// Command
    /// </summary>
    public ICommand ICommand {
        get {
            return new MyCommand((o)=> {
                MessageBox.Show(MenuName);
            });
        }
    } 

    public MenuInfo(string menuName, MenuInfo parentMenu)
    {
        MenuName = menuName;
        //将当期菜单挂载到父菜单下面
        if (parentMenu != null)
        {
            List<MenuInfo> lists = parentMenu.SubMenus ?? new List<MenuInfo>();
            lists.Add(this);
            parentMenu.SubMenus = lists;
        }
    }
}
-------------------------------------------------------------------------
/// <summary>
/// 自定义实现ICommand
/// </summary>
class MyCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public Action<object> ExecuteAction;

    public MyCommand(Action<object> executeAction)
    {
        ExecuteAction = executeAction;
    }

    public bool CanExecute(object parameter)
    {
        return true;
        //throw new NotImplementedException();
    }

    public void Execute(object parameter)
    {
        if (this.ExecuteAction != null)
        {
            this.ExecuteAction(parameter);
        }
    }
}
```

##### 3.ContentMenu

`IsCheckable`表示是否可被选中
`IsChecked`表示是否被选中，如果该项可被取消选中，则要加`IsCheckable`属性
`Separator`标签表示分割线

```xaml
<Label Width="300" Height="40" Content="Label for MenuContext"
       FontSize="20">
    <Label.ContextMenu>
        <ContextMenu>
            <MenuItem Header="bold" IsCheckable="True"/>
            <MenuItem Header="italy" IsChecked="True"/>
            <Separator/>
            <MenuItem Header="Size"/>
        </ContextMenu>
    </Label.ContextMenu>
</Label>
```

##### 4.TabControl

一次只有一个`TabItem`内容可见

```xaml
<TabControl>
    <TabItem Header="tab1">
        This tab1 Content
    </TabItem>
    <TabItem Header="tab2">
        <Grid>
            <Label HorizontalAlignment="Left" Width="200" Height="100" Content="label" />
            <Button HorizontalAlignment="Right" Width="200" Height="100" Content="button"/>
        </Grid>
    </TabItem>
    <TabItem>
        <TabItem.Header>
            <Label Content="tab3"/>
        </TabItem.Header>
    </TabItem>
</TabControl>
```

##### 5.ToolBar

```xaml
<ToolBar HorizontalAlignment="Center" VerticalAlignment="Top" Height="30">
    <Label Content="label"/>
    <Separator/>
    <Button Content="button1"/>
</ToolBar>
```

##### 6.ToolBarTray

`ToolBarTray`管理里面的数个`ToolBar`
`Orientation`设置排列方向
`Band`可区分该`ToolBar`位于哪一行或列，默认0
`BandIndex`设置出现的先后顺序，默认0

```xaml
<ToolBarTray Orientation="Vertical">
    <ToolBar VerticalAlignment="Top" Band="0" BandIndex="2">
        <Label Content="label"/>
        <Separator/>
        <Button Content="button1"/>
    </ToolBar>
    <ToolBar VerticalAlignment="Top" Band="0" BandIndex="0">
        <Label Content="label2"/>
        <Separator/>
        <Button Content="button2"/>
    </ToolBar>
</ToolBarTray>
```

##### 7.ListBox

`SelectionMode`设置选中模式，Extended表示可使用ctrl和shift键

```xaml
<ListBox Width="100" SelectionMode="Extended">
    <ListBoxItem>1000</ListBoxItem>
    <ListBoxItem>2000</ListBoxItem>
    <ListBoxItem>3000</ListBoxItem>
    <ListBoxItem>4000</ListBoxItem>
</ListBox>
```

```xaml
<!--Dynamic binding-->
<ListBox Name="listBox" Width="100" HorizontalAlignment="Right" SelectionMode="Extended"
         ItemsSource="{Binding}">
    <ListBox.ItemTemplate>
        <DataTemplate DataType="{x:Type ListBoxItem}">
            <TextBlock Text="{Binding}"/>
        </DataTemplate>
    </ListBox.ItemTemplate>
</ListBox>
```

##### 8.DataGrid

`AutoGenerateColumns`是否可自动增加列

```xaml
<DataGrid Width="300" Height="200" AutoGenerateColumns="False">
    <DataGrid.Columns>
        <DataGridTextColumn Header="Text"></DataGridTextColumn>
        <DataGridCheckBoxColumn Header="CheckBox"></DataGridCheckBoxColumn>
        <DataGridComboBoxColumn Header="ComboBox"></DataGridComboBoxColumn>
    </DataGrid.Columns>
</DataGrid>
```

动态添加数据

```xaml
<Grid Name="Grid" Loaded="Grid_Loaded">
    <DataGrid Width="300" Height="200" AutoGenerateColumns="False"
              Name="DataGrid" Loaded="DataGrid_Loaded" ItemsSource="{Binding}">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}"></DataGridTextColumn>
            <DataGridTextColumn Header="Age" Binding="{Binding Age}"></DataGridTextColumn>
            <DataGridComboBoxColumn x:Name="deptColumn" Header="ComboBox" SelectedValueBinding="{Binding Dept}"></DataGridComboBoxColumn>
        </DataGrid.Columns>
    </DataGrid>
</Grid>
```

```C#
private void Grid_Loaded(object sender, RoutedEventArgs e)
{
    List<UserInfo> userInfos = new List<UserInfo>();
    userInfos.Add(new UserInfo() { Name = "zhangsan", Age = 10, Dept = 1 });
    userInfos.Add(new UserInfo() { Name = "lisi", Age = 20, Dept = 2 });
    Grid.DataContext = userInfos;
}

private void DataGrid_Loaded(object sender, RoutedEventArgs e)
{
    List<DeptInfo> deptInfos = new List<DeptInfo>();
    deptInfos.Add(new DeptInfo() { ID = 1, Name = "AA" });
    deptInfos.Add(new DeptInfo() { ID = 2, Name = "BB" });
    deptColumn.ItemsSource = deptInfos;
    deptColumn.DisplayMemberPath = "Name";
    deptColumn.SelectedValuePath = "ID";
}
```

```C#
internal class UserInfo
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Dept { get; set; }
}
internal class DeptInfo
{
    public int ID { get; set; }
    public string Name { get; set; }
}
```

自定义模板列，可添加按钮、选择框等控件用于操作行数据

```xaml
<DataGridTemplateColumn>
    <DataGridTemplateColumn.Header>
        Column4
    </DataGridTemplateColumn.Header>
    <DataGridTemplateColumn.CellTemplate>
        <DataTemplate>
            <TextBlock>
                any
            </TextBlock>
        </DataTemplate>
    </DataGridTemplateColumn.CellTemplate>
</DataGridTemplateColumn>
```

可对数据进行排序，分组和过滤的操作，下面对年龄倒序排序
因为上一步对数据上下文进行了绑定，而ItemsSource还为空，故传递的参数是Grid.DataContext

```C#
ICollectionView cvTasks = CollectionViewSource.GetDefaultView(Grid.DataContext);
if (cvTasks != null && cvTasks.CanSort)
{
    cvTasks.SortDescriptions.Clear();
    cvTasks.SortDescriptions.Add(new SortDescription("Age", ListSortDirection.Descending));
}
```

##### 9.TreeView

```xaml
<TreeView VerticalAlignment="Bottom">
    <TreeViewItem Header="one" IsExpanded="True">
        <TextBlock>one</TextBlock>
        <TreeViewItem Header="one_1"></TreeViewItem>
        <TreeViewItem Header="one_2">
            <TreeViewItem Header="sub"/>
        </TreeViewItem>
    </TreeViewItem>
    <TreeViewItem Header="two"/>
</TreeView>
```

```xaml
<TreeView VerticalAlignment="Top" Name="Tree" ItemsSource="{Binding}">
    <TreeView.ItemTemplate>
        <HierarchicalDataTemplate DataType="{x:Type c:DeptInfo}" ItemsSource="{Binding ID}">
            <StackPanel Orientation="Horizontal">
                <Image Source="../Image/pic.jpg" Width="50" Height="50"/>
                <TextBlock Text="{Binding Name}"/>
            </StackPanel>
        </HierarchicalDataTemplate>
    </TreeView.ItemTemplate>
</TreeView>
```

### 五、布局控件

**部分布局控件可替换、可嵌套**

##### 1.Grid

由列和行组成的灵活的网格区域
第一行为第二行的两倍
第二列为自动填充

```xaml
<Grid.RowDefinitions ShowGridLines="True">
	<RowDefinition Height="2*"/>
    <RowDefinition/> Height="*"
</Grid.RowDefinitions>
<Grid.ColumnDefinitions>
	<ColumnDefinition Width="50"/>
	<ColumnDefinition/> Width="*"
</Grid.ColumnDefinitions>
```

##### 2.StackPanel

将子元素排列成垂直和水平的一行，默认垂直
`Opacity`设置透明度

```xaml
<StackPanel Orientation="Horizontal"  Opacity="0.5">
    <Label Width="50" Content="lbone"/>
    <Label Width="50" Content="lbtwo"/>
</StackPanel>
```

##### 3.DockPanel

定义一个区域，可以按相对位置垂直或水平排列各个子元素
`LastChildFill`设置最后子元素是否填充剩余区域，默认是
为True时有宽度居中填充对应宽度，为False时有宽度按方向填充对应宽度

```xaml
<DockPanel Background="Beige" LastChildFill="True">
    <StackPanel DockPanel.Dock="Left" Background="Red" Width="50"></StackPanel>
    <StackPanel DockPanel.Dock="Top" Background="Black" Height="100"></StackPanel>
    <StackPanel DockPanel.Dock="Bottom" Background="Green" Height="100"></StackPanel>
    <StackPanel DockPanel.Dock="Right" Background="White" Width="100"></StackPanel>
    <DockPanel DockPanel.Dock="Right" Background="Purple" LastChildFill="False" >
        <DockPanel DockPanel.Dock="Right" Background="Teal" Width="30">
        </DockPanel>
    </DockPanel>
</DockPanel>
```

##### 4.WrapPanel

按从左到右的顺序位置定位子元素，在包含框的边缘处将内容切换到下一行，后续排序按从上到下，从右到左的顺序进行，具体取决`Orientation`的值
当前宽度可容下控件时，则并列，超出宽度则换行

```xaml
<WrapPanel Width="400" Orientation="Horizontal">
    <Label FontSize="20" Content="按从左到右的顺序"/>
    <Label FontSize="20" Content="位置定位子元素"/>
    <StackPanel Height="100" Background="Yellow" Width="150"></StackPanel>
    <StackPanel Height="100" Background="Yellow" Width="150"></StackPanel>
    <StackPanel Height="100" Background="Yellow" Width="150"></StackPanel>
</WrapPanel>
```

##### 5.Canvas

定义一个区域，使用相对坐标定位子元素

```xaml
<Canvas Width="180" HorizontalAlignment="Left" Background="Teal">
    <StackPanel Background="Red" Height="100" Width="100" Canvas.Top="100" Canvas.Left="40"/>
    <StackPanel Background="GreenYellow" Height="100" Width="100" Canvas.Top="200" Canvas.Left="40"/>
</Canvas>
```

##### 6.UniformGrid

在有限的空间内为子元素均分空间。

### 六、其它控件

##### 1.Calendar

`SelectionMode`选中的模式
`DisplayData`显示的日期
`SelectedData`选中的日期
当显示的日期超出显示日期的范围时，将自动延长到显示日期

```xaml
<Calendar HorizontalAlignment="Right" SelectionMode="MultipleRange"
          DisplayDate="2022-3-1" SelectedDate="2022-3-1"
          DisplayDateStart="2021-1-1" DisplayDateEnd="2021-12-12">
</Calendar>

<DatePicker Width="100" HorizontalAlignment="Right" VerticalAlignment="Bottom"/>
</Grid>
```

##### 2.Image

1. 相对路径，当图片生成操作为资源或内容时有效
2. 应用下的路径，当图片生成操作为资源或内容时有效
3. 站点下的路径，当图片生成操作为内容时有效

当选择图片生成操作为内容时，复制到输出目录选择如果较新则复制

```xaml
<Image Source="1.png" Stretch="Fill"/>
<Image Grid.Row="1" Source="pack://Application:,,,/1.png" Stretch="UniformToFill"/>
<Image Grid.Row="2" Source="pack://siteoforigin:,,,/1.png" Stretch="None"/>
```

文字内嵌图片
`TileMode`平铺模式
`Viewport`获取或设置TileBrush的基本图块的位置和尺寸
`ViewPortunits`指定Viewport的值

```xaml
<TextBlock Grid.Row="3" Background="Orange" FontSize="50" TextAlignment="Center">
    <TextBlock.Foreground>
        <ImageBrush ImageSource="1.png" TileMode="Tile"
                    Viewport="0,0,30,30" ViewportUnits="Absolute"/>
    </TextBlock.Foreground>
    Text
</TextBlock>
```

##### 3.ProgressBar

```xaml
<ProgressBar Name="Progress" Foreground="Blue" Background="AliceBlue" Width="400"
             Height="100" Minimum="0" Maximum="100" Loaded="Progress_Loaded"/>
```

```C#
Timer timer = new Timer();
private void Progress_Loaded(object sender, RoutedEventArgs e)
{
    timer.Interval = 1000;
    timer.Elapsed += Timer_Elapsed;
    timer.Start();
}

private void Timer_Elapsed(object sender, ElapsedEventArgs e)
{
    Dispatcher.Invoke(() =>
                      { 
                          Progress.Value += 10;
                      });
}
```

##### 4.Rectangle

`Fill`填充色
`Stroke`边缘色
`StrokeThickness`边缘宽
`StrokeDashArray`设置边缘虚线
`RadiusX``RadiusY`设置圆角

```xaml
<Rectangle VerticalAlignment="Bottom" Width="200" Height="100"
           Fill="BlueViolet" Stroke="Black" StrokeThickness="8"
           StrokeDashArray="5" RadiusX="50" RadiusY="50"/>
```

```xaml
<Rectangle VerticalAlignment="Center" Width="200" Height="100" Stroke="Black" StrokeThickness="8"
           StrokeDashArray="2" RadiusX="50" RadiusY="50">
    <Rectangle.Fill>
        <VisualBrush>
            <VisualBrush.Visual>
                <StackPanel>
                    <TextBlock FontSize="2" HorizontalAlignment="Center" Text="PICTURE"></TextBlock>
                    <Image Source="1.png"/>
                </StackPanel>
            </VisualBrush.Visual>
        </VisualBrush>
    </Rectangle.Fill>
</Rectangle>
```

```xaml
<Rectangle VerticalAlignment="Center" Width="200" Height="100" Stroke="Black" StrokeThickness="8"
           StrokeDashArray="2" RadiusX="50" RadiusY="50">
    <Rectangle.Fill>
        <DrawingBrush>
            <DrawingBrush.Drawing>
                <ImageDrawing ImageSource="1.png" Rect="0,0,200,100"/>
            </DrawingBrush.Drawing>
        </DrawingBrush>
    </Rectangle.Fill>
</Rectangle>
```



### N、控件补充事项

##### 11.命名空间

引用名称为 entity 的命名空间

```xaml
xmlns:c="clr-namespace:entity"
```

##### 12.数据绑定

1. 在xaml内绑定，使用静态资源绑定直观显示

   ```xaml
   <Grid.Resources>
       <c:MyData x:Key="myDataSource"/>
   </Grid.Resources>
   <Grid.DataContext>
       <Binding Source="{StaticResource myDataSource}"/>
   </Grid.DataContext>
   <Button Background="{Binding Path=colorName}"
           Width="{Binding Path=Width}" Height="100" Content="Turn to red color"/>
   ```

   ```C#
   public class MyData
   {
       public string colorName { get; set; } = "Red";
       private int width = 100;
       public int Width { get => width; set => width = value; }    
   }
   ```

2. 在类内绑定，需要运行之后才能看到效果

   ```xaml
   <Label Name="myLabel" Width="100" Height="20" VerticalAlignment="Top" />
   ```

   ```C#
   public string text { get; set; } = "This is a label";
   
   private void Grid_Loaded(object sender, RoutedEventArgs e)
   {
       MyData myData = new MyData();
       myLabel.Content = myData.text;
       myLabel.Height = 30;
   }
   ```

##### 3.根据控件名给控件背景赋值

```C#
(grid.FindName("b" + index) as Border).Background = new SolidColorBrush(Colors.Teal);
```

##### 4.控件的属性也可作为标签

##### 5.控件内如果需要填充多行文本，可使用`<TextBlock>`标签

##### 6.模板

建立某个控件的模板，减少代码冗余

```xaml
<Window.Resources>
    <ControlTemplate x:Key="myGroupBox" TargetType="GroupBox">
        <GroupBox Header="Groupbox header">
            <Grid>
                <TextBlock>
                    asdf dsad <LineBreak/>
                    sdafa
                </TextBlock>
                <CheckBox Margin="0,40">check me</CheckBox>
            </Grid>
        </GroupBox>
    </ControlTemplate>
</Window.Resources>

// using template
<Grid>
	<GroupBox Template="{StaticResource myGroupBox}"/>
</Grid>
```

### 其它

##### 1.使用类启动WPF项目

```C#
// Delete App.xaml, add class Program.cs
static class Program
{
    [STAThread]
    static void Main(String[] args)
    {
        MainWindow win = new MainWindow();
        win.Show();
    }
}
```



## 深入浅出

### 一、tips

##### 1.外部编译程序

```shell
csc MyApp.txt
csc /r:"D:\DLL\xx.dll" /t:exe MyApp.txt
```

编译目标可以是exe、winexe、library

`Windows`标签的`windowStyle`属性可更改窗体样式

##### 2.xmlns指xaml namespace，允许一个没有别名的默认的命名空间，

```xaml
xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
```

`<Window>、<Grid>`等标签都来自于上述命名空间

给命名空间添加别名时，同时需要给来自于此命名空间的标签也添加别名前缀

```xaml
<n:Window x:Class="WpfApp1.MainWindow"
        xmlns:n="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800" WindowStyle="ThreeDBorderWindow">
    <n:Grid></n:Grid>
</n:Window>
```

##### 3.xaml和其cs类似winform，是部分类，共同编译成一个类

`x:Class="WpfApp.MainWindow"`指的是所属的部分类，当其名称和cs类的类名不一致时，则重新编译一个类

##### 4.TypeConverter

重写ConvertFrom，提供一种统一的方法将类型的值转换为其他类型，以及用于访问标准值和子属性

```xaml
<Window.Resources>
    <local:Human x:Key="human" Name="Tim" Child="Little"/>
</Window.Resources>
<Grid>
    <Button Content="content" Width="100" Height="100" Click="Button_Click"/>
</Grid>
```

```C#
private void Button_Click(object sender, RoutedEventArgs e)
{
    Human human1 = this.FindResource("human") as Human;
    //if (human1 != null)
    //{
    MessageBox.Show(human1?.Child.Name);
    //}
}

[TypeConverterAttribute(typeof(NameToHuman))]
public class Human
{
    public string Name { get; set; }
    public Human Child { get; set; }
}


public class NameToHuman : TypeConverter
{
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        string name = value.ToString();
        Human child = new Human();
        child.Name = name;
        return child;
    }
}
```

##### 5.XAML中为对象属性赋值

①attrbute=value

②属性标签

```xaml
<Button  Width="100" Height="100" Click="Button_Click">
    <Button.Content>
    	<Rectangle Width="20" Height="20" Fill="LawnGreen" Stroke="Black"/>
    </Button.Content>
</Button>
```

③标签扩展

##### 8.添加项目外的控件或窗体

①添加控件或窗体项目的引用

②

```xaml
<!--                    项目名					项目名		-->
xmlns:cl="clr-namespace:ControlLibrary;assembly=ControlLibrary" 
<!--控件或窗体的类名-->
<cl:MyControl/>
```

##### 6.x:ClassModify ，指定部分类生成类的访问修饰符

x:FieldModify ，指定控件的访问修饰符

##### 6MVVM图览

![1-1-1](https://gitee.com/mrbm868/graphic-bed/raw/master/img/WPF_MVVM1-1.png)

![1-1-2](https://gitee.com/mrbm868/graphic-bed/raw/master/img/WPF_MVVM1-2.png)

是否需要继承NotificationObject类看对象是否要通知UI，即是否需要作为Binding的Source，且值发生变化

##### 9.Binding

Binding即要指定Path和Source，没有指定Source的话会往父标签一层一层地查找，直到`<Window>`

### 二、MVVM

##### 11.MVVM和Prism的关系

[WPF框架Prism中使用MVVM架构_实用技巧_脚本之家 (jb51.net)](https://www.jb51.net/article/237149.htm)

![](https://gitee.com/mrbm868/graphic-bed/raw/master/img/WPF_MVVM1-4.png)

##### 12.简单MVVM

①数据属性的实现

```C#
class NotificationObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void RaisePropertyChanged(string propertyName)
    {
        if (PropertyChanged != null) { this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));}
    }
}
```

```C#
private double _input1;

public double Input1
{
    get { return _input1; }
    set
    {
        _input1 = value;
        this.RaisePropertyChanged("Input1");
    }
}
```

②命令属性的实现

```C#
class DelegateCommand : ICommand
{
    public Action<object> ExecuteAction { get; set; }

    public Func<object, bool> CanExecuteFunc { get; set; }

    public bool CanExecute(object? parameter)
    {
        if (CanExecuteFunc == null) return true;
        return this.CanExecuteFunc(parameter);
    }

    public void Execute(object? parameter)
    {
        if (ExecuteAction == null) return;
        this.ExecuteAction(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}
```

```C#
public DelegateCommand AddCommand { get; set; }

private void Add(object parameter) => this.Result = this.Input1 + this.Input2;

this.AddCommand = new DelegateCommand { ExecuteAction = this.Add };
```



##### 13.Prism-Region

![](https://gitee.com/mrbm868/graphic-bed/raw/master/img/WPF_MVVM-Region.png)

定义Region的两种方式

①在XAML中指定

```xaml
<ContentControl prism:RegionManager.RegionName="ContentRegion"/>
```

②在代码中指定

```XAML
<ContentControl Name="main"/>
```

```C#
RegionManager.SetRegionName(main, "ContentRegion");
```

RegionManager还有以下功能

- 维护区域集合
- 提供对区域的访问
- 合成视图
- 区域导航
- 定义区域

##### 14.Prism-Module

创建Module的方式

- AppConfig
- Code
- Directory
- LoadManual
- Xaml

视图注入

```C#
public class ModuleModule : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
        var regionManager = containerProvider.Resolve<RegionManager>();

        var region = regionManager.Regions["ContentRegion"];
        region.RequestNavigate(nameof(ViewA));
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
    	containerRegistry.RegisterForNavigation<ViewA>();
    }
}
```

##### 15.Prism中的MVVM

①Prism中自动绑定`View`和`ViewModel`

```
prism:ViewModelLocator.AutoWireViewModel="true"
// Replace to
this.DataContext = new ViewAViewModel();
```

②复合命令`CompositeCommand`

```C#
private string _text;

public string Text
{
    get { return _text; }
    set { _text = value; RaisePropertyChanged(); }
}

public DelegateCommand ShowCommand1 { get; private set; }

public DelegateCommand ShowCommand2 { get; private set; }

public CompositeCommand AllCommand { get; private set; }

this.Text = "Heell";
ShowCommand1 = new DelegateCommand(() =>
{
     this.Text += "Show1 ";
});
ShowCommand2 = new DelegateCommand(() => { this.Text += "SHow2 ";});

AllCommand = new CompositeCommand();

AllCommand.RegisteredCommands.Add(ShowCommand1);
AllCommand.RegisteredCommands.Add(ShowCommand2);
```

③订阅、发布、事件聚合器

常用于不同界面的数据传递

```C#
public class MessageEvent : PubSubEvent<string>
{

}
public DelegateCommand SubmitCommand { get; private set; }
public DelegateCommand SendCommand { get; private set; }

private readonly IEventAggregator _eventAggregator;

public MainWindowViewModel(IEventAggregator enAggregator)
{
    this._eventAggregator = enAggregator;
    SubmitCommand = new DelegateCommand(() =>
	{
     	enAggregator.GetEvent<MessageEvent>().Subscribe((OnMessageReceived));
     });
    SendCommand = new DelegateCommand(() =>
    {
         enAggregator.GetEvent<MessageEvent>().Publish("OKKKK");
    });
}
```

④事件过滤器、取消订阅

用于区别不同页面

```C#
SubmitCommand = new DelegateCommand(() =>
{
     enAggregator.GetEvent<MessageEvent>().Subscribe(OnMessageReceived,
     ThreadOption.PublisherThread, false, msg =>
     {
          if (msg.Equals("OKKKK")) return true;
           else return false;
     });
});

SendCommand = new DelegateCommand(() =>
{
       enAggregator.GetEvent<MessageEvent>().Unsubscribe(OnMessageReceived);//.Publish("OKKKK");
});
```

##### 16.Prism—Navigation

```c#
//--------------MainWindowViewModel------------------------------
public DelegateCommand OpenACommand { get; private set; }

public DelegateCommand OpenBCommand { get; private set; }

private readonly IRegionManager _regionManager;
public MainWindowViewModel(IRegionManager regionManager)
{
    this._regionManager = regionManager;

    OpenACommand = new DelegateCommand(() => { this._regionManager.RequestNavigate("ContentRegion", "PageA");});
    OpenBCommand = new DelegateCommand(() => { this._regionManager.RequestNavigate("ContentRegion", nameof(BView)); });
}
//---------------App.xaml.cs------------------------
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterForNavigation<AView>("PageA");
    containerRegistry.RegisterForNavigation<BView>();
}
```

①需要传递参数时

```C#
//---------------------AView.xaml----------------------
<TextBlock FontSize="30" Text="{Binding Text}"></TextBlock>
//---------------------AViewModel.cs-------------------
public class AViewModel : BindableBase, INavigationAware
{
    private string _text;

    public string Text
    {
        get { return _text; }
        set { _text = value;
             RaisePropertyChanged();
            }
    }

    /// 导航完成前接收用户传递的参数
    public void OnNavigatedTo(NavigationContext navigationContext)
    {
        this.Text = navigationContext.Parameters.GetValue<string>("Value");
    }

    /// 判断是否打开过当前导航，返回true创建新实例
    public bool IsNavigationTarget(NavigationContext navigationContext)
    {
        return true;
    }

    /// 导航离开当前页触发
    public void OnNavigatedFrom(NavigationContext navigationContext)
    {

    }
} 
//---------------------MainWindowViewModel.cs-----------
OpenACommand = new DelegateCommand(() =>
{
    NavigationParameters param = new NavigationParameters();
    param.Add("Value", "hello!!");
    this._regionManager.RequestNavigate("ContentRegion", "PageA", param);
});
// Replace to, like get mode to transfer
OpenACommand = new DelegateCommand(() =>
{
    this._regionManager.RequestNavigate("ContentRegion", $"PageA?Value=Hello!!");
});
```

②确认是否导航弹窗

```C#
public class AViewModel : BindableBase, IConfirmNavigationRequest
{
    public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
    {
        bool result = true;
        if (MessageBox.Show("确认导航", "提示", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            result = false;
        continuationCallback(result);
    }
}
```

③导航日志，实现向前和向后

```C#
public DelegateCommand BackCommand { get; private set; }

public DelegateCommand ForwardCommand { get; private set; }

private readonly IRegionManager _regionManager;

private IRegionNavigationJournal _journal;
public MainWindowViewModel(IRegionManager regionManager)
{
    this._regionManager = regionManager;

    OpenACommand = new DelegateCommand(() =>
    {
         this._regionManager.RequestNavigate("ContentRegion", $"PageA?Value=Hello!!", arg =>
         {
               _journal = arg.Context.NavigationService.Journal;
         });
    });
    OpenBCommand = new DelegateCommand(() =>
    {
           this._regionManager.RequestNavigate("ContentRegion", nameof(BView), func =>
           {
                _journal = func.Context.NavigationService.Journal;
           });
    });

    BackCommand = new DelegateCommand(() => { this._journal.GoBack(); });
    ForwardCommand = new DelegateCommand(() => { this._journal.GoForward(); });
}
```

##### 17.Prism—Dialog

```C#
//--------------App.xaml.cs---------------
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterDialog<MsgView, MsgViewModel>("alias");
}
//--------------MsgViewModel.cs---------------
public class MsgViewModel : BindableBase, IDialogAware
{
    public DelegateCommand ConfirmCommand { get; private set; }

    public DelegateCommand CancelCommand { get; private set; }

    public MsgViewModel()
    {
        ConfirmCommand = new DelegateCommand(() =>
        {
            DialogParameters param = new DialogParameters();
            param.Add("Value", this.Title);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, param));
        });
        CancelCommand = new DelegateCommand(() =>
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        });
    }

    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {
    }

    //获取到弹窗打开前传递的参数
    public void OnDialogOpened(IDialogParameters parameters)
    {
        string v = parameters.GetValue<string>("Value");
        MessageBox.Show(v);
    }

    public string Title { get; set; }
    public event Action<IDialogResult> RequestClose;
}
//--------------MainViewModel.cs------------------
private readonly IDialogService _dialog;
public MainWindowViewModel(IRegionManager regionManager, IDialogService dialog)
{
    this._dialog = dialog;

    DialogCommand = new DelegateCommand(() =>
	{
          DialogParameters param = new DialogParameters();
          param.Add("Value", "Test");
           //发送弹窗前的数据
          dialog.ShowDialog("alias", param, arg =>
          {
              string v = string.Empty;
              if (arg.Result == ButtonResult.OK)
              {
                  //接收弹窗输入的数据
                   v = arg.Parameters.GetValue<string>("Value");
              }

              MessageBox.Show(v);
           });
    });
}
```

