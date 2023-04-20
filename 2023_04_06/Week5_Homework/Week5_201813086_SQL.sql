create database gamedb;

use gamedb;

create table Players (
	id integer primary key, 
    email varchar(48) unique, 
    nickname varchar(24) not null, 
    passwd varchar(24) not null, 
    check(email like '%@%')
);

alter table Players modify id integer not null auto_increment;

insert into Players(email, nickname, passwd) VALUES('zhdlxh48@gmail.com', 'MayB', 'testpasswd');
insert into Players(email, nickname, passwd) VALUES('testemail01@gmail.com', 'testnick', 'testpasswd01');

select * from Players;

create table Items (
	id integer not null auto_increment primary key, 
    itemName varchar(36) not null, 
    itemType int not null, 
    itemDesc varchar(512) not null
);

insert into Items(itemName, itemType, itemDesc) VALUES('HP포션', 100, 'HP를 100 회복합니다');
insert into Items(itemName, itemType, itemDesc) VALUES('MP포션', 100, 'MP를 100 회복합니다');

insert into Items(itemName, itemType, itemDesc) VALUES('강철검', 400, '여행을 떠나는 초보자에게 주어지는 검, 투박하지만 튼튼하다');

select * from Items;
select * from Items where itemType = 400;
select * from Items where itemName like '%포션';
