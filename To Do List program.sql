create database toDoList;

use todoList;

create table User(
id_user int auto_increment primary key,
name varchar(100),
password varchar(30) not null
);

create table Task(
id_task int auto_increment primary key,
title varchar(200),
date_created datetime default current_timestamp,
task_completed bool default false,
id_user int,

constraint userTask foreign key(id_user) references User(id_user)
);

insert into User(name,password)
values('Juanito','2409921'),('Carmelina','12345'),('Luisito','908tgf54'),('Martin','674rew5');

insert into Task(title,id_user)
values
('buy the dinner',3),
('Change the light tub',3),
('Read a book',1),
('Go for a run',1),
('Fix the car',4),
('Paint the living room',4),
('Prepare a presentation',2),
('Call mom',2);

insert into Task(title,task_completed,id_user)
values('Wash my car',true,3);

Delimiter //
create procedure selectUserTask() 
begin

	select name, title, date_created, Task.task_completed
	from User
	left join Task on User.id_user = Task.id_user;

end//
Delimiter ;

Delimiter //
create procedure selectTaskFromUser(id_ofUser int) 
begin

	select title
	from Task
	where id_user= id_ofUser;

end//
Delimiter ;

delete from User where name='wanerklk';

call selectUserTask();
call selectTaskFromUser(2);
-- drop database toDoList;
