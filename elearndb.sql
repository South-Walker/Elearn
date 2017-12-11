drop view elearndb.wechat_process_view;
drop view elearndb.wechat_student_view;
drop table elearndb.processes;
drop table elearndb.ewords;
drop table elearndb.parts;
drop table elearndb.students;
drop table elearndb.wechatids;
drop schema elearndb;

create schema elearndb

create table elearndb.wechatids
(
    user_id int identity(0,1),
    wechat_id varchar(40),
    followdate datetime not null DEFAULT getdate(),
    PRIMARY KEY (user_id)
);
create table elearndb.students
(
    user_id int,
    studentnum varchar(10),
    jwcpassword varchar(11),
    PRIMARY KEY (user_id),
    foreign key (user_id) references elearndb.wechatids(user_id)
);
create table elearndb.parts
(
    part_id int identity(0,1),
    bookname varchar(20),
    unitname varchar(10),
    partname varchar(10),
    PRIMARY KEY (part_id)
);
create table elearndb.ewords
(
    eword_id int identity(0,1),
    eword varchar(30) not null,
    chinese varchar(40),
    wordpart varchar(10),
    part_id int,
    PRIMARY KEY (eword_id),
    foreign KEY (part_id) references elearndb.parts(part_id)
);
create table elearndb.processes
(
    user_id int,
    eword_id int,
    part_id int,
    PRIMARY KEY (user_id),
    foreign key (user_id) references elearndb.students(user_id),
    foreign key (eword_id) references elearndb.ewords(eword_id),
    foreign key (part_id) references elearndb.parts(part_id)
);

create view elearndb.wechat_student_view as
select elearndb.wechatids.wechat_id,elearndb.students.studentnum,elearndb.students.jwcpassword
from elearndb.wechatids left join elearndb.students
on wechatids.user_id = students.user_id;

create view elearndb.wechat_process_view as
select elearndb.wechatids.wechat_id,elearndb.processes.eword_id,elearndb.processes.part_id
from elearndb.wechatids left join elearndb.processes
on wechatids.user_id = processes.user_id;

insert elearndb.parts values('综合教程3','Unit1','Part2');

insert elearndb.ewords values('frustration','挫折；令人失望','n.',0);
insert elearndb.ewords values('suburban','郊外的，郊区的','adj.',0);
insert elearndb.ewords values('contentment','知足，满足','n.',0);
insert elearndb.ewords values('self-reliant','依靠自己的，独立的','adj.',0);
insert elearndb.ewords values('honey','蜂蜜','n.',0);
insert elearndb.ewords values('canoe','划（或乘）独木舟','v.',0);
insert elearndb.ewords values('ski','滑雪','vi.',0);
insert elearndb.ewords values('low','（牛）哞哞叫','n.',0);
insert elearndb.ewords values('hawk','鹰','n.',0);
insert elearndb.ewords values('corn','玉米田','n.',0);
insert elearndb.ewords values('haul','（用卡车、马车等)搬运','vt.',0);
insert elearndb.ewords values('firewood','木柴','n.',0);
insert elearndb.ewords values('sled','雪橇','n.',0);
insert elearndb.ewords values('strawberry','草莓','n.',0);
insert elearndb.ewords values('retile','重新用瓦盖','vt.',0);
insert elearndb.ewords values('long-overdue','拖了很久的','adj.',0);
insert elearndb.ewords values('overdue','早该有的，早该发生的','adj.',0);
insert elearndb.ewords values('improvement','改进，改善','n.',0);
insert elearndb.ewords values('supplement','补充，增补','vt.',0);
insert elearndb.ewords values('indoor','室内的','adj.',0);
insert elearndb.ewords values('chick','小鸡','n.',0);
insert elearndb.ewords values('typewriter','打字机','n.',0);
insert elearndb.ewords values('freelance','自由撰稿人（或演员等）','n.',0);
insert elearndb.ewords values('pursue','努力去获得（或完成），追求','vt.',0);
insert elearndb.ewords values('oversee','看管；监督','vt.',0);
insert elearndb.ewords values('beehive','蜂窝，蜂箱','n.',0);
insert elearndb.ewords values('organ','风琴；器官','n.',0);
insert elearndb.ewords values('overflow','溢出，泛滥','vi.',0);
insert elearndb.ewords values('swamp','淹没；压倒','vt.',0);
insert elearndb.ewords values('freezer','冰柜，冷藏室(冰箱中的)冷冻室','n.',0);
insert elearndb.ewords values('cherry','樱桃','n.',0);
insert elearndb.ewords values('raspberry','树莓，覆盆子','n.',0);
insert elearndb.ewords values('asparagus','芦笋','n.',0);
insert elearndb.ewords values('canned-goods','罐装品','n.',0);
insert elearndb.ewords values('plum','李子，梅子','n.',0);
insert elearndb.ewords values('jelly','果子冻','n.',0);
insert elearndb.ewords values('squash','南瓜属植物（如南瓜、倭瓜、笋瓜等）','n.',0);
insert elearndb.ewords values('pumpkin','n．南瓜','',0);
insert elearndb.ewords values('gallon','加仑','n.',0);
insert elearndb.ewords values('decidedly','肯定地，无疑地','adv.',0);
insert elearndb.ewords values('employer','雇佣者；雇主','n.',0);
insert elearndb.ewords values('blessing','祝福；鼓励','n.',0);
insert elearndb.ewords values('bless','为…祝福','vt.',0);
insert elearndb.ewords values('den','兽穴','n.',0);
insert elearndb.ewords values('illustrate','加插图于；举例说','n.',0);
insert elearndb.ewords values('hitch','用挽具套住','vt.',0);
insert elearndb.ewords values('dogsled','狗拉雪橇','n.',0);
insert elearndb.ewords values('monster','怪物，妖怪','n.',0);
insert elearndb.ewords values('digest','文摘；摘要','n.',0);
insert elearndb.ewords values('boundary','边界线；分界线','n.',0);
insert elearndb.ewords values('wilderness','荒野，荒地','n.',0);
insert elearndb.ewords values('generate','形成，产生','vt.',0);
insert elearndb.ewords values('dental','牙的，和牙有关的','adj.',0);
insert elearndb.ewords values('insurance','保险；保险费','n.',0);
insert elearndb.ewords values('policy','保险单，保险契约；政策','n.',0);
insert elearndb.ewords values('fee','费','n.',0);
insert elearndb.ewords values('minor','较少的，较小的，较次要的','adi.',0);
insert elearndb.ewords values('premium','保险费；奖金，奖品','n.',0);
insert elearndb.ewords values('appreciably','能够感到地；可观地','adv.',0);
insert elearndb.ewords values('lower','降低','v.',0);
insert elearndb.ewords values('patronize','光顾，惠顾','vt.',0);
insert elearndb.ewords values('opera','歌剧','n.',0);
insert elearndb.ewords values('ballet','芭蕾舞（剧）','n.',0);
insert elearndb.ewords values('extravagant','奢侈的，浪费的','adj.',0);
insert elearndb.ewords values('combine','（使）结合；（使）联合','v.',0);
insert elearndb.ewords values('suspect','相信，怀疑','v.',0);
insert elearndb.ewords values('solitude','孤独，独居','n.',0);
insert elearndb.ewords values('budget','预算','n.',0);
insert elearndb.ewords values('involve','使参加；使陷入；包含，牵涉','vt.',0);
insert elearndb.ewords values('requirement','要求；必备条件','n.',0);
insert elearndb.ewords values('self-sufficiency','自给自足','n.',0);
insert elearndb.ewords values('scale','规模','n.',0);
insert elearndb.ewords values('resist','抵制','vt.',0);
insert elearndb.ewords values('temptation','诱惑（物）','n.',0);
insert elearndb.ewords values('laborsaving','省力的；节省劳动力的','adj.',0);
insert elearndb.ewords values('device','设备，装置','n.',0);
insert elearndb.ewords values('machinery','（总称），机械','n.',0);
insert elearndb.ewords values('horsepower','马力','n.',0);
insert elearndb.ewords values('rotary','旋转的','adj.',0);
insert elearndb.ewords values('cultivator','耕耘机','n.',0);
insert elearndb.ewords values('profit','得益；收益，利润','n.',0);
insert elearndb.ewords values('invest','投资','v.',0);
insert elearndb.ewords values('economic','经济学的；经济（方面）的','adj.',0);
insert elearndb.ewords values('old-fashioned','过时的，老式的；守旧的','adj.',0);
