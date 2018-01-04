using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    // Employee info
    class Employee
    {
        // It's the unique ID of each node.
        // unique id of this employee
        public int id;
        // the importance value of this employee
        public int importance;
        // the id of direct subordinates
        public List<int> subordinates;
    }

    class Employee_Importance
    {
        public int getImportance(List<Employee> employees, int id)
        {
            var emp = employees.Find(e => e.id == id);
            var ret = emp.importance;
            List<int> ids = new List<int>(emp.subordinates);
            while (ids.Count > 0)
            {
                var tmp = employees.Find(e => e.id == ids[0]);
                ids.RemoveAt(0);
                ret += tmp.importance;
                if(tmp.subordinates != null && tmp.subordinates.Count > 0)
                    ids.AddRange(tmp.subordinates);
            }
            return ret;
        }
    }
}
