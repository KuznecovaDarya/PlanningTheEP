   M S B A M L   `   `   `  ????H  DPlanningTheEP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PlanningTheEPPlanningTheEP  5          PlanningTheEP.AddFullPlan   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PlanningTheEP     5        N? Title$  AddFullPlan??5	       N? 
Background
 ?????.??5      ?  ? ColumnDefinitions 5   
   ?? 5      $??* ?6   6+   ?? 5      $??* ?6   6+    ? RowDefinitions 5   
   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   ?? 5      $??* ?6   6)   .+?5   
   ?? $??Center=?6   $??Center=?61   $2??,Название Учебного плана??6L   $??0??6k   $??20(?6x   6?   ?? 5   
   $??Center=?6   $??Center=?61   $??Тип??6L   $??1??6W   $??20(?6d   6t   ?? 5   
   -   5         ??Name$
 Name??5   a   $??30??6   $??Center=?6   $??20(?69   $??0??6o   $??1??6|   
???/?????6G   ?? *
NamePlan+6?   ?? 5   
   -   5         ??Name$ Types??5   f   $??30??6   $??Center=?6   $??20(?6:    ?? DisplayMemberPath$
 Name??6u    ?? 
IsEditable .  ?? 
IsReadOnly .  	 ?? StaysOpenOnEdit	 . $??1??6?   $??2??6?   
???/???
 ?? SelectedItem
 6H   ?? *Type+6  ?? 5   
   -   5        $??BtnSave??5   ?   $??40??6   $??Center=?6   $??20(?68   
???/???$??Сохранить??6_   $??2??6s   $??8??6?   6?   5      5      