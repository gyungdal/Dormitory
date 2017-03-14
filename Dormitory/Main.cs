﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dormitory
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        /*
         * 1. 학생 명부 관리
         *      Excel 데이터에서 학생 명부 (학번, 이름, 등등) 저번에 짰던거 이쪽에서 불러와서 표 형태 (DataGridView 같은거)로 출력
         *      직접 바로 수정도 가능하게
         *      여기에는 벌점이랑 무관하게 학생들 정보들만 들어감
         * 2. 벌점 관리
         *      여기가 메인 기능임
         *      일단 검색 기능. 이름 학번 등 저번에 나왔던 내용들 토대로 검색하는 기능 넣는 것
         *      벌점 및 상점을 주는 방식은 일단 마음대로해도 됨 (콤보박스, 버튼, 직접입력 등등) 일단 우리 마음대로 해놓고 나중에 수정해줘도 힘들거 없음
         *      학년별, 벌점별 정렬 같은거 기능 하나 추가
         * 3. 권한 관리
         *      이건 교사 측에서 해당되는 내용임
         *      최고 관리자 / 사감 / 일반교사 -> 이렇게 되어야 할 거 같음
         *      최고 관리자만 사용 및 접근 가능한 폼(버튼)을 추가해서 대상별 권한 설정 가능하게 부여할 수 있도록 함
         * 
         *      미안하다 경식아 치킨 살게
         * 
         * */
    }
}
