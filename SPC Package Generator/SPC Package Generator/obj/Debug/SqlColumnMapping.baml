   M S B A M L   `   `   `  ����  SPC Package Generator,    &SPC_Package_Generator.SqlColumnMapping   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  SqlColumnMapping��5   	   $	��650��6"   $	��700��6/   .��5      ��  �� Orientation$ Vertical=�5   	   .+�5   
   �� $��24(�5      .��6   SQL Integration5
      � 5   
   -   5         �Name$ gridSqlTable��5      $��20,20,20,10q�5      .+�5      �� -   5         ��Name$ spanel_FileName��5      $ Vertical=�62   $��0��6I   .+�5      �� $��20(�6   $��Suggested Task Name��6&   �� 5      -   5        $��filename_Label��5      $
��....��6.   $��5,0,10,0q�6=   $��40��6O   5      �� 5      -   5        $ spanel_SqlTable��5      $ Vertical=�62   $��1��6I   .+�5      �� $��20(�6   $��Suggested SQL Table Name��6&   �� 5      -   5        $��sqlTable_TextBox��5      $��5,0,10,0q�62   $��30��6D   $	��250��6P   $
��Left=�6\   5       � ColumnDefinitions 5      �� 5      $��1* �5      �� 5      $��1* �5      5      �� 5    
   $��2q�6   
����ح�$��0,0,0,20q�6=   ._�5!   
   �� $	��350��6   .��5"      &   System.Windows.Controls.DataGrid  -   5        $��mainGridView��5"   3      AutoGenerateColumns .  $��10q�6G      Columns 5#      4  .System.Windows.Controls.DataGridCheckBoxColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ Include��61      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6e   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6C   �� 
 �� Path$
 Include�6e   0  *System.Windows.Controls.DataGridTextColumn  5%      $ File Column��6-   $	 195 6f   	 6B   �� $
 
FileColumn�6f     5&      $ Actual Column��6-   $	 195 6j   	 6D   �� $
 ActualColumn�6j   4  .System.Windows.Controls.DataGridComboBoxColumn  5'      $ 	Data Type��61   -   5        TypeColumnComboBox��$	 195 5*         SelectedValueBinding 5(      �� *
TypeColumn+ �� Mode$ TwoWay=�   DisplayMemberPath 5)      �� *
TypeColumn+5*        5+      $ Nullable��61   $ 60 6g   	 6D   �� $
 Nullable�6g   5-      5.      5/      �� 51   
   -   5        $��Generate Scripts��51   0   $��40��6K   $	��120��6W   53      54      