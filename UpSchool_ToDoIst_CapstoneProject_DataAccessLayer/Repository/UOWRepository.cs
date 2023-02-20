﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Abstract;
using UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Concrete;

namespace UpSchool_ToDoIst_CapstoneProject_DataAccessLayer.Repository
{
    public class UOWRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;

        public UOWRepository(Context context)
        {
            _context = context;
        }

        public void Delete(T t)
        {
            _context.Remove(t);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return _context.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}