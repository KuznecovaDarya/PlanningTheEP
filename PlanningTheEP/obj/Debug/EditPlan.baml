   M S B A M L   `   `   `  ????H  DPlanningTheEP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PlanningTheEPPlanningTheEP  5          PlanningTheEP.EditPlan   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PlanningTheEP     5        N? Title$  EditPlan??5	       N? 
Background
 ?????.??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??200 ?6   6-   ?? 5      $??* ?6   6+    ? RowDefinitions 5   
   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   .+?5   
   ?? $??Center=?6   $??Center=?61   $)??#Предметная область??6L   $??0??6f   $??20(?6s   6?   ?? 5   
   $??Center=?6   $??Center=?61   $??Предмет??6L   $??1??6[   $??20(?6h   6x   ?? 5   
   $??Center=?6   $??Center=?61   $%??Количество часов??6L   $??2??6d   $??20(?6q   6?   ?? 5   
   $??Center=?6   $??Center=?61   $??
Класс??6L   $??3??6Y   $??20(?6f   6v   ?? 5   
   -   5         ??Name$ SArea??5   P   $??20(?6    ?? DisplayMemberPath$
 Name??6_    ?? 
IsEditable .  ?? 
IsReadOnly .   ?? StaysOpenOnEdit . $??0??6?   $??1??6?   	 ?? SelectedItem	 6!   ?? *FirstPlan.SubjectArea+6?   ?? 5   
   -   5        $ Subject??5   L   $??20(?6   $
 Name??6]    .  .   . $??1??6?   $??1??6?   	 6!   ?? *FirstPlan.Subject+6?   ?? 5   
   -   5        
 ??Name$	
 NOH??5   I   $??20(?6   $??2??6V   $??1??6c   ??6    ?? *FirstPlan.NumberOfHours+6u   ?? 5    
   -   5        $ Grades??5    J   $??20(?6   $
 Name??6Z    .  .   . $??3??6?   $??2??6?   	 6!   ?? *FirstPlan.Grade+6?   ?? 5"   
   -   5        $??BtnSave??5"   y   
???/???$??Сохранить??6*   $??2??6>   $??40??6R   $??20(?6^   $??8??6l   6?   5#      5$      