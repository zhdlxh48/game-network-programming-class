create user 'test'@'localhost' identified by 'RealTjshd*499';

grant all privileges on *.* to 'test'@'localhost';

create database ckgame;

use ckgame;

create table scores (
	distance float default 0.0, 
    time float default 0.0
);

insert into scores (distance, time) values (10.3451, 5.1425);

select * from scores;

select * from scores order by distance asc LIMIT 4;