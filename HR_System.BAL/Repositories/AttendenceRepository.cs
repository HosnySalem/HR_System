﻿using HR_System.BAL.Interfaces;
using HR_System.BAL.Reposatories;
using HR_System.DAL.Data;
using HR_System.DAL.Models;
using HR_System.DAL.ViewModelsForUpdate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BAL.Repositories
{
    public class AttendenceRepository : GenericRepository<Attendence>, IAttendenceRepository
    {
        public AttendenceRepository(HRDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Attendence>> GetAllAttendnce(int year, int month)
        {
            return await _dbContext.Attendences.Include(x => x.Employee)
                                               .ThenInclude(x => x.Department)
                                               .Where(attendance => attendance.Day.Year == year &&
                                                      attendance.Day.Month == month)
                                               .ToListAsync();
        }

        public async Task<List<Attendence>> GetAllAttendnce(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.Attendences
                                                .Include(x => x.Employee)
                                                .ThenInclude(x => x.Department)
                                                .Where(attendance => attendance.Day >= startDate && attendance.Day <= endDate)
                                                .ToListAsync();
        }

     

        public async Task<Attendence> GetEmployeeAttendenceById(int id)
        {
            return await _dbContext.Attendences.Include(x => x.Employee).
                ThenInclude(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAttendence(UpdateEmployeeAttendence attendenctModel)
        {
            var attendenceFromDB = await _dbContext.Attendences.FirstOrDefaultAsync(x => x.Id == attendenctModel.Id);

            if (attendenceFromDB != null)
            {
                attendenceFromDB.AttendenceTime = attendenctModel.AttendenceTime;
                attendenceFromDB.LeavingTime = attendenctModel.LeavingTime;
                attendenceFromDB.Day = attendenctModel.DayDate;
                attendenceFromDB.EmoloyeeId = attendenctModel.EmployeeId;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
