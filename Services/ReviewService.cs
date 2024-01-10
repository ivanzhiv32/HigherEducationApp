using HigherEducationApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HigherEducationApp.Data;
using System.Text.RegularExpressions;

namespace HigherEducationApp.Services
{
    class ReviewService
    {
        string path = "D:\\Учеба\\Диплом\\HigherEducationApp\\Files\\feedbacks_clear.csv";
        public List<ReviewOfInstitution> AddReview()
        {
            List<string[]> reviews = GetReviews();
            List<ReviewOfInstitution> result = new List<ReviewOfInstitution>();

            int index = 0;
            using (HigherEducationSystemDbContext educationSystemContext = new HigherEducationSystemDbContext())
            {
                foreach (var review in reviews)
                {
                
                    var institutions = educationSystemContext.Institutions
                        .Include(c => c.Reviews)
                        .Where(c => c.Name.Contains(review[2])).ToList();
                    if (institutions.Count == 0) 
                    {
                        institutions = educationSystemContext.Institutions
                        .Include(c => c.Reviews)
                        .Where(c => c.Site.Contains(review[0])).ToList();
                    }

                    foreach (var institution in institutions)
                    {
                        index++;
                        institution.Reviews.Add(new ReviewOfInstitution(institution, Convert.ToInt32(review[4]), review[5], review[3]));
                        //result.Add(new ReviewOfInstitution(institution, Convert.ToInt32(review[4]), review[5], review[3]));
                    }
                    educationSystemContext.SaveChanges();
                }
                
            }

            return result;
        }

        public List<string[]> GetReviews()
        {
            List<string[]> reviews = new List<string[]>();
            using (var reader = new StreamReader(path, Encoding.GetEncoding(1251)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if(values.Length != 6)
                    {
                        string text = "";
                        foreach (var value in values)
                        {
                            text += value;
                        }
                        reviews.Last()[5] += text;
                        continue;
                    }
                    reviews.Add(values);
                }
            }
            return reviews;
        }
    }
}
