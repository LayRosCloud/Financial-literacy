   M S B A M L   `   `   `  ????E  AAppGramota, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:AppGramota
AppGramota  5   	       AppGramota.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:AppGramota     5   	     ? Title$+  %финансовое обучение??5   	   $	??450??6%   $	??900??62   $	??450??6>   $	??900??6N    ? WindowStartupLocation$ CenterScreen=?6]    ? WindowState$ 	Maximized=?6?    ? Icon$ icon.ico??6?   .??5	      ? -   5         ?Name$ gridHub??5	      ???	#FFEAE3C4 ? ColumnDefinitions 5
   
   ?? 5      $??0.25* ?6   ?? 5      $??1* ?6   .+?5   
   ?? ??5      ?? 5       ?? Color$ #3D8361??6"   5      ? 5   
    ? RowDefinitions 5      ?? 5      $??50 ?6    ?? 5      $??50 ?6    ?? 5      $??1* ?6    .+?5      ?? $1??+Финансовая грамотность??6   ???#FFF$
??Bold"?5      $??Center=?5      $??Center=?5      ?? 5       ?? Orientation$ 
Horizontal=?6   $??1??62   ???#1C6758.+?5       ?? $??Images/avatar.png??6   ?? 5!      $??Center=?6   .+?5"      ?? -   5        	 ??Name$	 nameProfile??5"       $%??имя пользователя??5#       ???#FFF$
??Bold"?5%       ?? 5&      $ 
Horizontal=?6!   .+?5'      ?? $??Images/star.png??6    $??15??5(       ?? 5)      -   5        $	 levelProfile??5)   $   $#??Уровень профиля??5*   $   ???#FFF
 J? Opacity$	
 0.6Q?5,   $   5-      ?? 5.      -   5        $	 numMoney??5.       $%??Количество монет??62   ???#FFF$	
 0.5Q?6\   5/      50      ?? 51      $??2??6   .+?52      ?? -   5        $??30??52      $??Игры??53         ButtonStyle#??[  54      $??0 3 0 0q?55      56      ?? 57      -   5        $??30??57      $??Магазин??58      #??[  59      $??0 3 0 0q?5:      5;      5<      5=       ? 5?   
   -   5          ?Name$ frameHub??5?      $??1??6"     ? NavigationUIVisibility$ Hidden=?62   ? 5B   
   -   5        $ dialogueBox??5B      $??0??6   $y?	Collapsed=?64   $??2??6K   .+?5C      ?? ???#000$	
 0.6Q?6$   ?? 5D      $ 
Horizontal=?6   $??Bottom=?62   $??Center=?6M   .+?5E      ? .+?5F      ?? $??75??6    $	??150??6+   $??Right=?68   ???#FFF6T   ?? 5G      $??75??6    $??16??6+   $??Right=?67   $	??Top=?6S   ???#1C67586k   ?? 5H      -	   5         ??Name$ 
imageHuman??5H      $	??150??60   $	??150??6<   5J      ? 5K      $	??400??6   $	??150??6#   .+?5L      ??  ?? CornerRadius$ 0 0 30 0??6   $??0q?66   ??5M      ?? 5N      $
 #FFF??6.   5P      ?? 5Q      -
   5        $	 	nameHuman??5Q       $
??Bold"?5S       $??14(?5T       ???#1C6758$??16??5V       $	??Top=?5W       ???#EEF2E6??5R       ?? *	NameHuman+5X       ?? 5Y      -   5        $	 sentence??5Y       $
??Bold"?5Z       $??14(?5[       $	??Top=?5\       ???#1C6758$
??0 16q?5^       $
??Wrap=?5_       ?? 5`      -   5         ??Name$ ContinueButton??5`      $	??150??5a      $??20??5b      #??[  5c      $??14(?5d      $??
Далее??5e      $??Right=?5f      $??Bottom=?5g      $??0 0 30 0q?5h      5i      5j      5k      ? 5m   
   -   5        $ enterNameBox??5m      $??2??6%   $y?	Collapsed=?69   .+?5n      ?? ??5o      ?? 5p      $
 #000??6&    ?? Opacity$	 0.6Q?63   5r      ? 5s      $	??250??6   $	??200??5t      .+?5u      ?? $ 20??6   ??5v      ?? 5w      $ 	#FFEAE3C4??6*   5y      ?? 5z      $??Center=?6   $??Center=?5{      .+?5|      ?? $??Введите имя:??6    $??20(?5}       ???	#FFF5F1E05~       ?? 5      -   5        $??enterNameTextBox??5      $??20(?5?      $	??200??6,   
?????? $??0 0 0 5q?5?      ???#1C67585?      ?? 5?      -   5        $ completeButton??5?      $??Подтвердить??5?      #??[  5?      5?      5?      5?      5?      5?      5?      