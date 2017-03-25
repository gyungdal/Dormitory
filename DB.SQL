USE DORMITORY;

create table log_data (
	user_uuid bigint not null,
	point_uuid int not null,
	point_value int not null,
	log_memo varchar(500) ,
	teacher_uuid bigint not null,
	create_time timestamp default current_timestamp
);

create table score_data(
	point_uuid int auto_increment,
	point_type int not null,
	point_memo varchar(200) not null,
	point_value_min int not null,
	point_value_max int not null,
	primary key (point_uuid)
);

create table student_data(
	user_uuid bigint auto_increment,
	user_name varchar(20) not null,
	user_school_number varchar(10) not null,
	user_school_room_number varchar(10) not null,
	primary key (user_uuid)
);

create table teacher_data(
	teacher_uuid bigint  auto_increment,
	user_name varchar(20) not null,
	permission_type int not null,
	id varchar(100) not null,
	password varchar(1000) not null,
	primary key (teacher_uuid)
);

create table permission_data(
	permission_type int not null,
	student_manage int not null,
	score_manage int not null
);

PERMISSION_TYPE
	0 : 관리자
	1 : 사감 선생님
	2 : 일반 선생님
(나머지 값들) : 1이면 가능, 0이면 불가능

//LOGIN
select * from teacher_data join permission_data on permission_data.permission_type = teacher_data.permission_type where teacher_data.id = (id) and teacher_data.password = (password)

//특정 학생의 점수 기록 가져오기
select * from log_data join score_data on score_data.point_uuid = log_data.point_uuid where score_data.user_uuid = (uuid)

//전체 학생 정보 전송
select * from student_data;

//상*벌점 목록 들고오는거
select * from score_data;

//로그 추가
insert into log_data (USER_UUID, POINT_UUID, POINT_VALUE, LOG_MEMO, TEACHER_UUID) VALUES (4, 3, 5, '넌 벌점이야', 1) ;
insert into log_data (USER_UUID, POINT_UUID, POINT_VALUE, LOG_MEMO, TEACHER_UUID) VALUES (4, 3, 3, '넌 벌점이야2', 1);
insert into log_data (USER_UUID, POINT_UUID, POINT_VALUE, LOG_MEMO, TEACHER_UUID) VALUES (4, 5, 2, '넌 상점이야', 1) ;
insert into log_data (USER_UUID, POINT_UUID, POINT_VALUE, LOG_MEMO, TEACHER_UUID) VALUES (4, 5, 1, '넌 상점이야2', 1);

//총 상*벌점 조회

select * from (select sum(log_data.point_value) from log_data 
join score_data on score_data.point_uuid = log_data.point_uuid 
join student_data on student_data.user_uuid = log_data.user_uuid
where log_data.user_uuid = 4 and score_data.point_type = 0
group by score_data.point_type) as a 
join (select sum(log_data.point_value) from log_data 
join score_data on score_data.point_uuid = log_data.point_uuid 
join student_data on student_data.user_uuid = log_data.user_uuid
where log_data.user_uuid = 4 and score_data.point_type = 1
group by score_data.point_type) as b
join (select log_data.user_uuid, student_data.user_name, 
student_data.user_school_room_number, student_data.user_school_number
from log_data
join score_data on score_data.point_uuid = log_data.point_uuid 
join student_data on student_data.user_uuid = log_data.user_uuid
group by score_data.point_type limit 1) as c;


select log_data.user_uuid, student_data.user_name,
student_data.user_school_number, student_data.user_school_room_number from log_data
join student_data on student_data.user_uuid = log_data.user_uuid
group by log_data.user_uuid;

select log_data.create_time, log_data.point_value,
score_data.point_type, log_data.log_memo, teacher_data.user_name
from log_data
join score_data on score_data.point_uuid = log_data.point_uuid
join student_data on student_data.user_uuid = log_data.user_uuid
join teacher_data on teacher_data.teacher_uuid = log_data.teacher_uuid
where student_data.user_uuid = (ID)