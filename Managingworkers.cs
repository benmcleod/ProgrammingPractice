using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

//http://www.reddit.com/r/dailyprogrammer/comments/21yuep/422014_challenge_156_intermediate_managing_workers/
namespace ManagingWorkers
{
    class Managingworkers
    {
        private int _maxDays;
        private List<Task> _tasks = new List<Task>();
        private List<Person> _p = new List<Person>();

        public static void Main(string[] args)
        {
            #region
            //input.txt

            //13,17
            //Preparation,2,Planning
            //Hiring,3
            //Legal,3
            //Briefing,4,Preparation
            //Advertising,4
            //Paperwork,5,Legal
            //Testing,5,Frontend
            //API,6
            //Backend,6
            //Planning,7
            //Frontend,8
            //Mobile,8
            //Documentation,9,API

            //output

            //5
            //1,API,1
            //1,Documentation,7
            //2,Frontend,1
            //2,Testing,9
            //2,Hiring,14
            //3,Planning,1
            //3,Preparation,8
            //3,Briefing,10
            //3,Advertising,14
            //4,Legal,1
            //4,Paperwork,4
            //4,Mobile,9
            //5,Backend,1
            //15

            #endregion

            Managingworkers main = new Managingworkers();
            main.parseInput();
            main.solve();
            main.printOutput();

        }

        private void parseInput()
        {
            string[] _fileInput = File.ReadAllLines("input.txt");
            
            List<string> _firstLine = _fileInput[0].Split(',').ToList();
            int _n = int.Parse(_firstLine.ElementAt(0));
            _maxDays = int.Parse(_firstLine.ElementAt(1));

            string[] _input = new string[3];
            for (int i = 1; i <= _n; i++)
            {
                _input = _fileInput[i].Split(',');

                if (_input.Length > 2)
                    _tasks.Add(new Task(_input[0], int.Parse(_input[1]), _input[2]));
                else
                    _tasks.Add(new Task(_input[0], int.Parse(_input[1])));
            }
        }

        private void solve()
        {
            foreach (Task _task in _tasks)
            {
                if (_task._dependency != null)
                {
                    Task _tempTask = _tasks.Find(r => r._name == _task._dependency);
                    int _tempTotalTime = 0;
                    while (_tempTask != null)
                    {
                        _tempTotalTime = _tempTask._d;
                        _tempTask = _tasks.Find(r => r._name == _tempTask._dependency);
                    }
                    _task._totalTime = _task._d + _tempTotalTime;
                }
            }

            //sort list in Descending order to prioritize tasks 
            _tasks = _tasks.OrderByDescending(r => r._totalTime).ToList();

            foreach (Task _task in _tasks)
            {
                if (_task._done == false)
                {
                    if (_p.Find(r => r._time > _task._totalTime) == null)
                    {
                        _p.Add(new Person(_maxDays));
                    }
                    int pIndex = _p.FindIndex(r => r._time > _task._totalTime);

                    List<Task> _tempList = new List<Task>();
                    Task _tempTask = _tasks.Find(r => r._name == _task._dependency);
                    while (_tempTask != null)
                    {
                        if (_tempTask._done == false)
                        {
                            _tempTask._done = true;
                            _tempList.Add(_tempTask);
                        }
                        _tempTask = _tasks.Find(r => r._name == _tempTask._dependency);
                    }
                    _tempList.Reverse();
                    _p[pIndex]._task.AddRange(_tempList);

                    _task._done = true;
                    _p[pIndex]._task.Add(_task);
                    _p[pIndex]._time -= _task._totalTime;
                }
            }

        }

        private void printOutput()
        {

            int time;
            int totaltime = 0;

            Console.WriteLine(_p.Count());
            for (int i = 0; i < _p.Count; i++)
            {
                time = 0;
                for (int j = 0; j < _p[i]._task.Count; j++)
                {
                    Console.WriteLine(i + 1 + "," + _p[i]._task[j]._name + "," + (time + 1));
                    time += _p[i]._task[j]._d;
                }
                totaltime += _maxDays - time;
                Debug.Assert(_maxDays - time >= 0);
            }
            Console.WriteLine(totaltime);

        }

    }

    public class Person
    {
        public int _time;
        public List<Task> _task = new List<Task>();

        public Person(int t)
        {
            this._time = t;
        }

    }

    public class Task
    {
        public bool _done;
        public string _name;
        public int _d;
        public string _dependency;
        public int _totalTime;

        public Task(string _name, int _d, string _dependency)
        {
            this._name = _name;
            this._d = _d;
            this._dependency = _dependency;
            this._totalTime = _d;
            this._done = false;
        }
        public Task(string _name, int _d)
        {
            this._name = _name;
            this._d = _d;
            this._totalTime = _d;
            this._done = false;
        }
    }
}