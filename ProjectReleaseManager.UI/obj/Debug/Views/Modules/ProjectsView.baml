   M S B A M L   `   `   `  ����S  OProjectReleaseManager.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:ProjectReleaseManager.UI.Views.Modules&ProjectReleaseManager.UI.Views.Modules  5      9    3ProjectReleaseManager.UI.Views.Modules.ProjectsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:ProjectReleaseManager.UI.Views.Modules     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      .��5      � $��2��6     � RowDefinitions  5   
   �� 5      $
��Auto �6   $��40��6*   �� 5      $��* �6   .+�5   
   ��  �� Padding$ 5q�6   $��0��6   ���#1e272e._�5      ��  �� Orientation$ 
Horizontal=�5      .+�5      ��   Caliburn.Micro.Message   Attach$ 
NewProject��5      $��1q�5      $
��Left=�5      $��5q�5      .��6!   New project release66   5      5      �� 5   
   ��. $
��Auto=�5      $��1��6>   .��5      &   System.Windows.Controls.DataGrid     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6      AutoGenerateColumns .     	RowHeight$ 40Q�5         
IsReadOnly .    CanUserResizeColumns .  	   CanUserDeleteRows	 .  
   CanUserAddRows
 .  ��5#   ,   �� *
Projects+   Columns 5$      4  .System.Windows.Controls.DataGridTemplateColumn  5%         CellTemplate 5&      �� 5'      .R�5(   "   �� $ 
Horizontal=�6-   .+�5)   &   �� $��1q�6-   $ EditProject($dataContext)��68   .��6h   Edit6n   �� 5*   &   $  ViewReleases($dataContext)��6-   $��1q�6]   .��6h   View Releases6w   5+   #   5,      5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Name+   ElementStyle 50      �� 51       �� 
TargetType" ��6$   .�52   "   ��  �� Property � �� �� Value$ DemiBold"�6?   �� 53   "    � ��$
 Left=�6H   �� 54   "    � ��$ Center=�6F   55      57        58      $ ProjectType��6)    6>   �� *ProjectType+ 59      �� 5:      " ��6$   .�5;   "   ��  � ��$ DemiBold"�6?   �� 5<   "    � ��$
 Left=�6H   �� 5=   "    � ��$ Center=�6F   5>      5@        5A      $ Source��6)    69   �� *DocumentationSource+ 5B      �� 5C      " ��6$   .�5D   "   ��  � ��$ DemiBold"�6?   �� 5E   "    � ��$
 Left=�6H   �� 5F   "    � ��$ Center=�6F   5G      5I        5J      $ Description��6)    6>   �� *Description+ 5K      �� 5L      " ��6$   .�5M   "   ��  � ��$ DemiBold"�6?   �� 5N   "    � ��$
 Left=�6H   �� 5O   "    � ��$ Center=�6F   5P      5R      5T      5U      5V      5W      