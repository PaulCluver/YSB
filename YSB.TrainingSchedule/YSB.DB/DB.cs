using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace YSB.DB
{
    public class Database
    {
        private string ConnectionString { get; set; }
        private int CurriculumID { get; set; }

        public Database()
        {
            this.ConnectionString = "Data Source=D101763;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public void InsertCurriculum(int animalID, DateTime startDate, DateTime endDate, int totalDays, int doneDays, int remainingDays, double totalWeeks, double doneWeeks, double remainingWeeks, string percentageDone)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = this.ConnectionString;
                conn.Open();

                SqlCommand cmd = new SqlCommand("[YSB].[dbo].InsertCurriculum", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AnimalID", animalID));
                cmd.Parameters.Add(new SqlParameter("@StartDate", startDate));
                cmd.Parameters.Add(new SqlParameter("@EndDate", endDate));
                cmd.Parameters.Add(new SqlParameter("@TotalDays", totalDays));
                cmd.Parameters.Add(new SqlParameter("@DoneDays", doneDays));
                cmd.Parameters.Add(new SqlParameter("@RemainingDays", remainingDays));
                cmd.Parameters.Add(new SqlParameter("@TotalWeeks", totalWeeks));
                cmd.Parameters.Add(new SqlParameter("@DoneWeeks", doneWeeks));
                cmd.Parameters.Add(new SqlParameter("@RemainingWeeks", remainingWeeks));
                cmd.Parameters.Add(new SqlParameter("@PercentageDone", percentageDone));
                cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.Int) { Direction = ParameterDirection.Output });

                cmd.ExecuteNonQuery();

                this.CurriculumID = Convert.ToInt32(cmd.Parameters["@NewID"].Value);
                conn.Close();
            }
        }

        public void InsertCurriculumItem(List<int> animalAttackMethodFormIDs, List<int> attackMethodsIDs, List<int> standingMethodsIDs, List<int> strategyIDs, List<int> turningMethodsIDs)
        {
            foreach (var id in animalAttackMethodFormIDs)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = this.ConnectionString;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[YSB].[dbo].InsertCurriculumAttackMethodForms", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ParentCurriculumID", this.CurriculumID));
                    cmd.Parameters.Add(new SqlParameter("@AttackMethodFormID", id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            foreach (var id in attackMethodsIDs)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = this.ConnectionString;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[YSB].[dbo].InsertCurriculumAttackMethods", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ParentCurriculumID", this.CurriculumID));
                    cmd.Parameters.Add(new SqlParameter("@AttackMethodsID", id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            foreach (var id in standingMethodsIDs)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = this.ConnectionString;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[YSB].[dbo].InsertCurriculumStandingMethods", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ParentCurriculumID", this.CurriculumID));
                    cmd.Parameters.Add(new SqlParameter("@StandingMethodID", id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            foreach (var id in strategyIDs)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = this.ConnectionString;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[YSB].[dbo].InsertCurriculumStrategies", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ParentCurriculumID", this.CurriculumID));
                    cmd.Parameters.Add(new SqlParameter("@StrategiesID", id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            foreach (var id in turningMethodsIDs)
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = this.ConnectionString;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("[YSB].[dbo].InsertCurriculumTurningMethods", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ParentCurriculumID", this.CurriculumID));
                    cmd.Parameters.Add(new SqlParameter("@TurningMethodsID", id));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}