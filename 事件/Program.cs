using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 事件
{
    public class HumanResoure
    {
        //事件处理函数
        public void SalaryHandler()
        {
            Console.WriteLine("好了,我开始计算薪水了，不要急");
        }

           


        static void Main(string[] args)
        {
            Employee empl = new Employee();
            HumanResoure hr = new HumanResoure();

            empl.OnSalary += new SalaryCompute(hr.SalaryHandler);//注册
            empl.FireEvent();   //触发事件

            Console.ReadKey();
        }
    }
    //声明一个委托类型, 没有参数，也没有返回类型
    public delegate void SalaryCompute();//
    public class Employee
    {
        public event SalaryCompute OnSalary;

        public virtual void FireEvent()  ///触发事件的方法
        {
            if(OnSalary!=null)
            {
                OnSalary();
            }
        }
    }

}
