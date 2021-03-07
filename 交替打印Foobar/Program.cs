﻿/**
 *
 * 我们提供一个类：

class FooBar {
  public void foo() {
    for (int i = 0; i < n; i++) {
      print("foo");
    }
  }

  public void bar() {
    for (int i = 0; i < n; i++) {
      print("bar");
    }
  }
}

两个不同的线程将会共用一个 FooBar 实例。其中一个线程将会调用 foo() 方法，另一个线程将会调用 bar() 方法。

请设计修改程序，以确保 "foobar" 被输出 n 次。

 

示例 1:

输入: n = 1
输出: "foobar"
解释: 这里有两个线程被异步启动。其中一个调用 foo() 方法, 另一个调用 bar() 方法，"foobar" 将被输出一次。

示例 2:

输入: n = 2
输出: "foobarfoobar"
解释: "foobar" 将被输出两次。


 */


using System;
using System.Threading;

namespace 交替打印Foobar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var fooBar = new FooBar(3);
            var printFoo = new Action(() => Console.WriteLine("Foo"));
            var printBar = new Action(() => Console.WriteLine("Bar"));

            void CallBack(object state) => fooBar.Foo(printFoo);
            void CallBack2(object state) => fooBar.Bar(printBar);

            ThreadPool.QueueUserWorkItem(CallBack);
            ThreadPool.QueueUserWorkItem(CallBack2);
        }

        public class FooBar
        {
            private int n;

            public FooBar(int n)
            {
                this.n = n;
            }

            private bool _needFoo = true;

            public void Foo(Action printFoo)
            {
                for (int i = 0; i < n; ++i)
                {
                    while (!_needFoo)
                    {
                        Thread.Yield();
                    }

                    printFoo();
                    _needFoo = false;
                }
            }

            public void Bar(Action printBar)
            {
                for (int i = 0; i < n; ++i)
                {
                    while (_needFoo)
                    {
                        Thread.Yield();
                    }

                    printBar();
                    _needFoo = true;
                }
            }
        }
    }
}