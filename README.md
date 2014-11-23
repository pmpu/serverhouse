<h1 align="right">serverhouse</h1>
<a align="left" href="https://github.com/pmpu/serverhouse/wiki/FAQ">FAQ и полезная информация</a>

## новые задачи
 - сайт
 - видео → 3d модель

<hr>

## new tasks - new screens
<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/36958f4164075133550040b4d12afc8fe57bcb36/other/images/screenshots/disk_animation_details.png"><br>
<i>(Animation HDD components view)</i>

<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/238e195e9c025cf384a3ca16a667884de4d76164/other/images/screenshots/hdd.jpg"><br>
<i>(New HDD)</i>

<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/master/other/images/screenshots/ssd.jpg"><br>
<i>(first SSD)</i>

<a href="http://www.youtube.com/watch?v=TzM7fh1nt-E" target="_blank"><img width="500"  src="http://img.youtube.com/vi/TzM7fh1nt-E/0.jpg"/></a><br>
<i>(titles video preview)</i><br><br>
<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/02d5c744028fc1aed2b6fc3c3b8d17598dc2adec/other/images/screenshots/hddinside.jpg"><br>
<i>(brand new HardDrive)</i>

<hr>

### Задачи мастера моделирования и аниматора (art6 и art8)
Улучшить первый жесткий диск – более детальная модель передней, обратной стороны.
Отдельная модель с <a href="http://comp-security.net/wp-content/uploads/harddisk.jpg">внутренностями</a><br>
Попробовать себя в анимации головок ЖД<br>
Создать SSD жесткий диск и его внутренности.<br>
У всего этого должна быть грубая текстура в монотонных цветах и минифайл с описанием какой цвет какому материалу физического мира соответствует, желательно высоко средне и низко полигональная модели (три модели, одна текстура на них всех).<br>

### Задачи мастера текстур (art7)
Вытрясти модель жесткого диска с грубыми текстуры, следуя видеотуториалу <a href="http://www.youtube.com/watch?v=rKpB_nFdeaQ&list=UU-toy9WMImypmLAiU9h_SzQ">тут</a><br>
Разобраться с базовыми материалами и параметрами доступными из кода<br>
Разобраться с тем как строятся графы и как работают функции<br>

### Пара мастер текстур (art7) + мастер моделирования (art6)
задача на выходе: по крайней мере один жесткий диск смоделированный в Майа, привнесенный в Юнити3Д с натянутой на него динамической текстурой. Желательно два (хотя бы один с внутренностями)<br>

### Задачи отдела интеграции (art9)
2Д графика для меню в технократичном стиле (это первая попытка, возможна дальнейшая модернизация), придумать рюшечки. Современное, чистое, простое, которое сможет задать ощущение простоты. Для всех основных компонентов меню, существующих в Unity 4.6 UI по умолчанию, создать префабы с этими компонентами в создаваемом вами стиле. <br>
Вдохновение брать <a href="http://www.webresourcesdepot.com/20-free-ui-graphics-for-website-layouts/">тут</a>, основные цвета попробовать белый с синим (выбрать тон) для обводок подсветок и т. п.

### Интегратор (art9) + UI программист(art2) + программист ответственный за коммуникации (code4)
Реализовать титры, используя компоненты UI, на которые можно попадать из главного меню, считывающие бинарный файл с группами роль + ее участники + их статус <br>
использовать <a href="https://code.google.com/p/protobuf-net/">protobuf</a> для сериализации данных<br>

### Арт Босс (art10)
Всюду быть в курсе, все понимать, всем помогать, не допускать появления мусора в системе контроля версий.<br>
Отобрать 2д иконки, которые можно бесплатно использовать в проекте<br>
Отобрать субстанции, которые бы хотелось использовать в проекте <a href="http://www.allegorithmic.com/products/database">например здесь</a> <br>
Отобрать unity-ассеты, потенциально пригодные для проекта <a href="https://www.assetstore.unity3d.com/en/">например здесь</a><br>

### UI программист (code2)
Реализовать компонент, позволяющий имея 2д спрайт вставить его в округлую рамку, немного расширяющую свои поля и подсвечивающую ободок при наведении<br>
Разобраться с тем можно ли применять текстуры-субстанции к элементам UI интерфейса, посмотреть, как можно с помощью Substance Designer работать со спрайтами\атласами, в которых много спрайтов, посмотреть, как модифицировать из кода параметры текстур-субстанций, которые в тоже время 2д спрайты; показать минипример<br>
Разобраться с анимацией спрайтов, как сделать ее гладкой (а ля <a href="https://unity3d.com/ru/unity/animation">Mechanim</a>), показать минипример<br>

### Клиентский программист (code1)
Научиться программно вызывать анимацию стрелочки; показать пример<br>
Разобраться с тем, как программно анимировать текстуры-субстанции; показать минипример, желательно с жестким диском<br>
Разобраться с тем, как программно анимировать шейдеры; показать минипример<br>

### Программист ответственный за коммуникации (code4)
Создание небольшого интерфейса на сервере. ASP.NET веб страницы с формой. База для хранения данных на ваш выбор;<br> база на проект одна (важна поддержка версионности записей. Реализовать используя NHibernate.Envers см <a hrf="http://www.primordialcode.com/blog/post/nhibernate-envers-quick-introduction">здесь</a>); все ASP.NET страницы живут в одном проекте для управления контентом титров (добавления новых групп участников и их заполнения и редактирования)<br>

### Серверный программист (code3)
Соучаствовать в работе программиста, ответственный за коммуникации в плане создания серверной части системы<br>
Разработать систему работы с пользователями с поддержкой регистрации и входа по <a href="http://dotnetopenauth.net/">OpenID</a><br>
Конкретно создать на ASP.NET веб страницу с формой входа, регистрации и сохранением сессии пользователя. База для хранения данных на ваш выбор; база на проект одна; все ASP.NET страницы живут в одном проекте.<br>

### Универсальный программист Босс (code5)
Всюду быть в курсе, все понимать, всем помогать, чистить код, анализировать архитектуру.



## test tasks
<img align="right" width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/master/other/images/roles.jpg">
<b>Code:</b><br>
  1_3dcubes<br>
  2_menu - <b>done</b><br>
  3_chat - <b>done</b><br>
  4_2dmap - <b>done</b><br>

<b>Design:</b><br>
  6_hardDrive - <b>done</b><br>
  7_texturedCabinet<br>
  8_animatedArrow - <b>done</b><br>
  9_unityProject (with designed models and animations)<br>

<br><br>
## screens


<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/master/other/images/screenshots/2dmap03102014.png"><br>
<i>(2D Map project)</i>

<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/master/other/images/screenshots/hard29092014.jpg"><br>
<i>(HardDrive project)</i>

<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/master/other/images/screenshots/arrow.jpg"><br>
<i>(Arrow project)</i>

<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/master/other/images/screenshots/chat29092014.jpg"><br>
<i>(chat project)</i>

<img width="500"  src="https://raw.githubusercontent.com/pmpu/serverhouse/master/other/images/screenshots/menu27092014.png"><br>
<i>(menu project)</i>



