   M S B A M L   `   `   `  ????H  DPlanningTheEP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PlanningTheEPPlanningTheEP  5          PlanningTheEP.Plan2   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PlanningTheEP     5      -   5          N? Title$  Plan1??5	       N? 
Background
 ?????.??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??30 ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGPlan??5         AutoGenerateColumns .     
IsReadOnly . $??20(?6Q      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$) #Предметная область??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6p   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   ?? *FirstPlan.SubjectArea.Name+6|     5      $ Предмет??6%   $ * 6a   	 66   ?? *FirstPlan.Subject.Name+6m     5      $ Кол.часов??6%   $	 100 6d   	 68   ?? *FirstPlan.NumberOfHours+6r     5      $ 
Класс??6%   $	 100 6]   
   SortDirection$
 	AscendingX?6i   	 64   ?? *FirstPlan.Grade.Name+6?   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 auto 6)      CellTemplate 5      ?? 5      .R?5      ??  ??Name$ BtnEdit??6%   -   5        $ ??Редактировать??5   6   $??1??6N   
???/???$??18(?6?    J? Effect 5   "   3  -System.Windows.Media.Effects.DropShadowEffect  5   &   5      5      5!      5#      ?? 5%   
   -   5        $ BtnPrint??5%      $??Печать??6#   $??1??64   $??25??6A   $	??100??6M   
???/???$??Right=?6r   $??18(?6?   $??0,0,35,0q?6?   $	??Top=?6?    5&        5'      5)      ?? 5*   
   -   5        $ BtnDel??5*      $??Удалить??6!   $??1??63   $??25??6@   $	??100??6L   
???/???$
??Left=?6q   $??18(?6?   $??30,0,0,0q?6?   $	??Top=?6?    5+        5,      5.      ?? 50   
   -   5        $ BtnAdd??50      $??Добавить??6!   $??25??64   $	??100??6@   
???/???$??Center=?6e   $??18(?6?   $??1??6?   $	??Top=?6?    51        52      54      ?? 56   
   -   5         ??Name$ id??56      $??1??6   $??30??6+   $
??Left=?66   {?.  $y?Hidden=?6c   57      58      