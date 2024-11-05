﻿using Core.Exceptions;
using ToDoOrganize.Models.Entities;

namespace TodoListify.Service.Rules;

public class ToDoBusinessRules
{
    public virtual void ToDoIsNullCheck(ToDo todo)
    {
        if (todo is null)
        {
            throw new NotFoundException("İlgili görev bulunamadı.");
        }
    }
}