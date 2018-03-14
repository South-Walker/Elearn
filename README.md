![](https://raw.github.com/South-Walker/Elearn/master/doc/logo.jpg)

Elearn - 基于微信的英语辅助教学系统
=========================

Elearn是本人用作参与2018上海市计算机应用大赛的作品，中途遇不可抗力终止，本项目不再更新<br><br>

本项目主要实现的功能如下：
* 基于教务处信息网的用户身份验证
* 单词录入和例句自动生成（扇贝Api）
* 单词发音学习（基于百度翻译SDK）
* 课文学习与听力训练的页面
* 在线口语练习与打分（基于重新用[C#封装的科大讯飞语音评测SDK](https://github.com/South-Walker/iFLYTEK_demo)），由于微信的语音文件格式不被其兼容，利用ffmpeg做了一次格式转换

效果图：
![](https://raw.github.com/South-Walker/Elearn/master/doc/NextWord.png)
![](https://raw.github.com/South-Walker/Elearn/master/doc/Speak.png)
![](https://raw.github.com/South-Walker/Elearn/master/doc/OralEnglish.png)