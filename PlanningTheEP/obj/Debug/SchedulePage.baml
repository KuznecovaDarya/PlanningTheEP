   M S B A M L   `   `   `  ????H  DPlanningTheEP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PlanningTheEPPlanningTheEP  5           PlanningTheEP.SchedulePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PlanningTheEP     5        N? Title$  SchedulePage??5	       N? 
Background
 ?????.??5      ?  ? RowDefinitions 5   
   ?? 5      $??40 ?6   ?? 5      $??* ?6   ?? 5      $??40 ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DGSchedule??5      $??20(?6'   $??1??65      AutoGenerateColumns .     
IsReadOnly .  {?. 
???????   CanUserAddRows .    CanUserDeleteRows .    Columns 5      4  .System.Windows.Controls.DataGridComboBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$'	 !Расписание уроков??6)   -   5        	CBSubject??
   DisplayMemberPath$

 Name??5         SelectedValuePath$ 
Id_Subject??6?      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6?      SelectedItemBinding 6W   ?? *	Subject+6?   5      ?? 5   
   -   5         ??Name$	 Del??5      $??Удалить??6   $??Right=?60   $	??Top=?6L   $	??150??6w   $??2??6?   $??20(?6?   
???/???$??0,0,10,0q?6?   ?? 5   
   -   5        $ Search??5      $??
Поиск??6!   $??Right=?61   $??Center=?6M   $	??150??6~   $??0??6?   $??20(?6?   
???/???$??
0,-1,10,10q?6?   ?? 5   
   -   5         ??Name$ CBGrade??5      $??20(?6$   $??0??62   
???/??? ?? DisplayMemberPath$
 Name??6w    ?? SelectedValuePath$ Id_Grade??6?    ?? 
IsEditable .  ?? 
IsReadOnly .   ?? StaysOpenOnEdit . $	??250??6?   $
??Left=?6?    ?? SelectedItem 6X   ?? *Grade+6?   ?? 5   
   -   5        $ CBDay??5      $??20(?6"   $??0??60   
???/???$
 Name??6s   $ Id_Day??6?    .  .   . $	??250??6?   $??Center=?6?    6V   ?? *Day+6?   ?? 5   
   -   5        $	 Add??5      $+??%Сохранить изменения??6   $??Center=?6<   $	??Top=?6Y   $	??250??6?   $??2??6?   $??20(?6?   
???/???$??10,0,0,0q?6?   5      5      