﻿using SimpleMVVM4Maui.Controls;
using SimpleMVVM4Maui.Models;
using SimpleMVVM4Maui.Sorting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleMVVM4Maui.ViewModels
{
    public class EmpViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableRangeCollection<EmpModel> _empList = new ObservableRangeCollection<EmpModel>();

        private string _result;

        private string _empId;
        private string _empName;

        private EmpModel _selectedItem;

        public ICommand SendCommand { get; } //생성자에서만 new할꺼면 private set없어도 된다.

        public ICommand ReturnValueCommand { get; }

        //public ICommand SortedCommand { get; set; }

        public EmpViewModel()
        {
            SortedCommand = new Command<DataGridHeader>(Sorted);

            List<EmpModel> Employees = new List<EmpModel>()
            {
                new EmpModel {EmpId = 1,  EmpName = "1", Addr="주소, 첫번째", Age = 11, GradeCode = "001"},
                new EmpModel {EmpId = 2,  EmpName = "2", Addr="주소, 두번째", Age = 12, GradeCode = "002"},
                new EmpModel {EmpId = 3,  EmpName = "3", Addr="주소, 세번째", Age = 13, GradeCode = "003"},
                new EmpModel {EmpId = 4,  EmpName = "4", Addr="주소, 네번째", Age = 14, GradeCode = "004"},
                new EmpModel {EmpId = 5,  EmpName = "5", Addr="주소, 다섯번째", Age = 15, GradeCode = "001"},
                new EmpModel {EmpId = 6,  EmpName = "6", Addr="주소, 여섯번째", Age = 16, GradeCode = "002"},
                new EmpModel {EmpId = 7,  EmpName = "7", Addr="주소, 일곱번째", Age = 17, GradeCode = "003"},
                new EmpModel {EmpId = 8,  EmpName = "8", Addr="주소, 여덟번째", Age = 18, GradeCode = "004"},
                new EmpModel {EmpId = 9,  EmpName = "9", Addr="주소, 아홉번째", Age = 19, GradeCode = "001"},
                new EmpModel {EmpId = 10,  EmpName = "10", Addr="주소, 열번째", Age = 20, GradeCode = "002"},
                new EmpModel {EmpId = 11,  EmpName = "11", Addr="주소, 첫번째", Age = 11, GradeCode = "001"},
                new EmpModel {EmpId = 12,  EmpName = "12", Addr="주소, 두번째", Age = 12, GradeCode = "002"},
                new EmpModel {EmpId = 13,  EmpName = "13", Addr="주소, 세번째", Age = 13, GradeCode = "003"},
                new EmpModel {EmpId = 14,  EmpName = "14", Addr="주소, 네번째", Age = 14, GradeCode = "004"},
                new EmpModel {EmpId = 15,  EmpName = "15", Addr="주소, 다섯번째", Age = 15, GradeCode = "001"},
                new EmpModel {EmpId = 16,  EmpName = "16", Addr="주소, 여섯번째", Age = 16, GradeCode = "002"},
                new EmpModel {EmpId = 17,  EmpName = "17", Addr="주소, 일곱번째", Age = 17, GradeCode = "003"},
                new EmpModel {EmpId = 18,  EmpName = "18", Addr="주소, 여덟번째", Age = 18, GradeCode = "004"},
                new EmpModel {EmpId = 19,  EmpName = "19", Addr="주소, 아홉번째", Age = 19, GradeCode = "001"},
                new EmpModel {EmpId = 20,  EmpName = "20", Addr="주소, 열번째", Age = 20, GradeCode = "002"}

            };

            EmpList.AddRange(Employees);
        }

        private void Sorted(DataGridHeader e)
        {
            Console.WriteLine(e.SortFlag);
            Console.WriteLine(e.SortingEnabled);
            Console.WriteLine(e.FieldName);

            if (!e.SortingEnabled)
            {
                return;
            }

            SortingOrder sortMethod;

            if (e.SortFlag == SortingOrder.None || e.SortFlag == SortingOrder.Ascendant)
            {
                sortMethod = SortingOrder.Descendant;
            }
            else
            {
                sortMethod = SortingOrder.Ascendant;
            }

            e.SortFlag = sortMethod;
            List<EmpModel> lst = EmpList.ToList();

            SortData.SortList(ref lst, e.SortFlag, e.FieldName);
            EmpList.Clear();
            EmpList.AddRange(lst, System.Collections.Specialized.NotifyCollectionChangedAction.Reset);
            //EmpList = new ObservableRangeCollection<EmpModel>(lst);

            lst.Clear();
        }

        private void Return()
        {
            Debug.WriteLine("return");
        }

        private void Send()
        {

            foreach (var item in EmpList)
            {
                Console.WriteLine(item.Grade.Code + ", " + item.GradeCode);
            }
        }


        public string Result
        {
            set
            {
                if (_result == value) return;
                _result = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }

            get { return _result; }
        }

        public string EmpId
        {
            set
            {
                if (_empId == value) return;
                _empId = value;

                NotifyPropertyChanged();
            }

            get { return _empId; }
        }

        public string EmpName
        {
            set
            {
                if (_empName == value) return;
                _empName = value;

                NotifyPropertyChanged();
            }

            get { return _empName; }
        }

        public ObservableRangeCollection<EmpModel> EmpList
        {
            get { return _empList; }

            set
            {
                if (_empList == value) return;
                _empList = value;

                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            //if(PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EmpModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                }
            }
        }
    }
}
