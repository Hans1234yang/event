using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件2
{
    class HumanResource
    {

        public void SalaryHandler(object sender,MyEventArgs e)   //事件处理函数， 参数要和委托类型的参数一致
        {                                                        //必须要一致

            Console.WriteLine("薪水是{0}",e.salary);
        }

        static void Main(string[] args)
        {
            Employee ep1 = new Employee();
            HumanResource hr = new HumanResource();

            MyEventArgs e = new MyEventArgs(11000);
            ep1.OnSalaryCompute += new SalaryCompute(hr.SalaryHandler);  ///让事件绑定 事件处理方法   

            ep1.FireEvent(e);    // 触发事件处理函数

            Console.ReadKey();
        }
    }

    //定义一个委托类型 。 有参数,无返回类型
    public delegate void SalaryCompute(object sender, MyEventArgs e);

    public class Employee
    {
        //定义一个事件
        public event SalaryCompute OnSalaryCompute; 

        public virtual void  FireEvent(MyEventArgs e)   ///触发事件的方法
        {
            if(OnSalaryCompute!=null)       //如果 事件不为空
            {
                OnSalaryCompute(this,e);     //触发事件
            }
        }

    }




    //定义事件参数
    public class MyEventArgs : EventArgs
    {
        public readonly double salary;
        public MyEventArgs(double _salary)
        {
            salary = _salary;
        }
    }
}
