# Pong

Целта на апликацијата е да се имплементира варијанта на познатата 2D игра [Pong](https://en.wikipedia.org/wiki/Pong), 
една од првите компјутерски игри, направена од [Atari](https://en.wikipedia.org/wiki/Atari) во 1972 година.  
  
  
[Gameplay од оригиналната Pong игра од Атари.](https://www.youtube.com/watch?v=fiShX2pTz9A&t=25s&ab_channel=andys-arcade)  

Играта се состои од два рекети (еден од левата и еден од десната страна на прозорецот на играта) и една топка.  
Рекетите се управувани од играчи и се движат вертикално (горе и доле), а топката се движи во сите насоки.  
Целта на играта е секој од играчите со движење на рекетот да не дозволи топката да помине низ неговата страна на прозорецот на играта 
и со удирање на топката да постигне гол на другата страна.  
Победник е играчот кој прв ќе даде онолку голови колку што е избраниот "target".  
Играта има **Singleplayer mode** (човер против компјутер) и **Multiplayer mode** (човек против човек).  
Топката почнува од средината на прозорецот и се движи во случајно избрана насока.  
Со секое удирање на топката со рекет брзината на топката се зголемува, со што играта станува се потешка и потешка.  
По постигнување на гол, позицијата на топката се ресетира повторно на средина на прозорецот и исто така нејзината брзина се ресетира на почетната.  
Откако рекет ќе ја удри топката, аголот под кој таа се одбива зависи од тоа со кој дел од рекетот била удрена.  
Како функционира тоа е опишано на следната слика:  

![Logika za odbivanje na topkata](https://user-images.githubusercontent.com/21019116/33454021-81ad0a10-d63d-11e7-8578-80b265f65bbd.png)  
  
[Имплементацијата](https://github.com/OliverNikolovski/Pong/blob/master/Pong/Game.cs) е направена на следниот начин:  
Кога топката се судира со рекетот, пресметувам колку далеку од центарот на рекетот се случил сударот (односно разликата меѓу y-координата на топката и центарот на рекетот):  
`float relativeIntersectY = ball.Y - (paddle.Y + paddle.Height / 2);`  
Ако должината на рекетот е 10 пиксели, оваа вредност ќе биде од -5 до 5 пиксели.  
Во случајов е од -PADDLE_HEIGHT / 2 до PADDLE_HEIGHT / 2.  
Оваа вредност ја викам "relative intersect" бидејќи е релативна во однос на рекетот.  
Потоа истата вредност ја нормализирам со тоа што ја делам со PADDLE_HEIGHT / 2, со што сега рангот на вредности ќе биде од -1 до 1:  
`float normalizedRelativeIntersectionY = relativeIntersectY / (paddle.Height / 2);`  
Потоа ја множам со максималниот агол под кој сакам топката да се одбие кога ќе удри на ивица од рекет (во случајов тоа е аголот PI / 4):  
`float bounceAngle = (float)Math.PI / 4 * normalizedRelativeIntersectionY;`  
Исто така, ја пресметувам и насоката во која топката треба да се движи по одбивање од рекетот (лево или десно). Ако се одбие од десниот рекет треба да се движи на лево, 
па насоката треба да биде негативна, ако се одбие од левиот рекет, насоката ќе биде позитивна:  
`int direction = ball.X > Window.Width / 2 ? -1 : 1;`  
И на крај, со помош на пресметаните агол и насока, ги пресметувам `VelocityX` и `VelocityY`, кои ја претставуваат насоката + брзината на топката:  
`VelocityX = direction * (float)Math.Cos(angle) * Speed;`  
`VelocityY = (float)Math.Sin(angle) * Speed;`  
  
---
  
Потребните компоненти и форми за играта се имплементирани со следните класи:
- [Ball.cs](https://github.com/OliverNikolovski/Pong/blob/master/Pong/Ball.cs):  
Класа која ја претставува топката и ги содржи потребните податоци и методи за исцртување и движење на топката.
- [Paddle.cs](https://github.com/OliverNikolovski/Pong/blob/master/Pong/Paddle.cs):  
Класа која претставува рекет во играта и ги содржи потребните податоци и методи за исцртување и движење на рекетот.
- [Game.cs](https://github.com/OliverNikolovski/Pong/blob/master/Pong/Game.cs):  
Главната класа која ја претставува играта и ги содржи податоците и методите за рендерирање на сите компоненти во играта, како и за нивно апдејтирање.
- [Difficulty.cs](https://github.com/OliverNikolovski/Pong/blob/master/Pong/Difficulty.cs):  
Енумерација која ги содржи различните нивоа на компјутерот за singleplayer mode.
- [Sounds.cs](https://github.com/OliverNikolovski/Pong/blob/master/Pong/Sounds.cs):  
Класа која ги содржи звуците во играта, како и методи за нивно пуштање.
- [HomeForm.cs](https://github.com/OliverNikolovski/Pong/blob/master/Pong/HomeForm.cs):  
Почетната форма која се појавува при стартување на играта. Тука корисникот одбира дали сака да игра против компјутерот или против друг човек.
- [OnePlayerSettingsForm.cs](https://github.com/OliverNikolovski/Pong/blob/master/Pong/OnePlayerSettingsForm.cs):  
Оваа форма се појавува кога корисникот ќе одбере да игра против компјутерот. Тука треба да ја одбере тежината на компјутерот и до колку голови ќе играат.
- [TwoPlayersSettingsForm.cs](https://github.com/OliverNikolovski/Pong/blob/master/Pong/TwoPlayersSettingsForm.cs):  
Оваа форма се појавува кога ќе се одбере опцијата за "човек против човек". Тука треба да се одбере до колку голови ќе се игра.
  
---
  
Кога ќе се стартува играта се појавува следната форма:  
  
![Home Form](https://github.com/OliverNikolovski/Pong/blob/master/homeform.png)  
  
Ако се одбере опцијата "One Player" се појавува следната форма каде играчот ја одбира тежината и до колку ќе се игра:  
  
![One Player](https://github.com/OliverNikolovski/Pong/blob/master/oneplayer.png)  
  
Ако се одбере опцијата "Two Players" се појавува следната форма каде играчите ја одбираат тежината и до колку голови ќе играат:  
  
![Тwo Players](https://github.com/OliverNikolovski/Pong/blob/master/twoplayers.png)  
  
Потоа, откако ќе се стисне "Play", почнува играта во нов прозорец:  
  
![Game](https://github.com/OliverNikolovski/Pong/blob/master/game.png)  
