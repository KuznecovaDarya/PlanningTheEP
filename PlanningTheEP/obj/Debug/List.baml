   M S B A M L   `   `   `  ????H  DPlanningTheEP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PlanningTheEPPlanningTheEP  5          PlanningTheEP.List   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PlanningTheEP     5      -   5          N? Title$,  &МАОУ Петелинская СОШ??5	       N? 
Background
 ?????.??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??30 ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DGPlansList??5      $??0??6(      AutoGenerateColumns .     
IsReadOnly . $??20(?6c      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6P   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 64   ?? *	Id_Plan+6^     5      $ Учебный план??6%   $ * 6X   	 6;   ?? *
NamePlan+6d   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 auto 6)   
   CellTemplate
 5      ?? 5      .R?5      ??  ??Name$ Go??6>   -   5        
???/???$??Перейти??5   J   $??95??6m   6z   5      5        5      $
 auto 6)   
 5       ?? 5!      .R?5"      ?? $	 Del??6>   -   5        
???/???$??Удалить??5"   K   $??95??6o   6|   5#      5%      5'      ?? 5*   
   -   5         ??Name$ 	TxtSearch??5*      $9??3Введите название для поиска??6%   $??20(?6H   $??1??6W   $	??541??6d   $??Center=?6q   6?   ?? 5+   
   -   5        $ 	BtnSearch??5+      $??
Найти??6$   $??20(?64   $??2??6B   $	??100??6O   
???/???$??Right=?6t   6?   ?? 5,   
   -   5        $ BtnAdd??5,      $??Добавить??6!   $??20(?64   $??2??6B   $	??100??6O   
???/???$
??Left=?6t   6?   5-      5.      