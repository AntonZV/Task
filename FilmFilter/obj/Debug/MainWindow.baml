   M S B A M L   `   `   `  ����  
FilmFilter    FilmFilter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
FilmFilter��5   	   $	��350��6   $	��525��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5
   
   �� -   5         ��Name$ mainStackPanel��5
   ,    �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��GenreFilter:��6   $��5q�60   $��71��6;   �� 5      $	��199��6Y   $��5q�6e   ��6   �� *	GenreText+ �� UpdateSourceTrigger$ PropertyChanged=�6e   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��CountryFilter:��6   $��5q�62   �� 5      $	��200��6[   $��5q�6g   ��6   �� *CountryText+$ PropertyChanged=�6g   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��DirectorFilter:��6   $��5q�63   �� 5      $	��200��6\   $��5q�6h   ��6   �� *DirectorText+$ PropertyChanged=�6h   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��ActorFilter:��6   $��5q�60   $��71��6;   �� 5      $	��199��6Y   $��5q�6e   ��6   �� *	ActorText+$ PropertyChanged=�6e   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��YearFilter:��6   $��5q�6/   $��71��6:   �� 5      $	��199��6X   $��5q�6d   ��6   �� *
YearText+$ PropertyChanged=�6d   5      5      &   System.Windows.Controls.DataGrid  5    
   $��2��6   $��5q�6       AutoGenerateColumns .  ��6+   �� *Items+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Title��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *title+6P     5#      $
 Year��6%    63   �� *year+6N     5$      $ Country��6%    66   �� *	country+6T     5%      $ Genre��6%    64   �� *genre+6P     5&      $ Summary��6%    66   �� *	summary+6T     5'      $ Director��6%    67   �� *director.info+6[     5(      $ Actors��6%    65   �� *	actorsAll+6U   5*      5+      5,      