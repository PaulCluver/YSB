using System;
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

                SqlCommand cmd = new SqlCommand("dbo.InsertCurriculum", conn);
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

                cmd.ExecuteNonQuery();

                this.CurriculumID = Convert.ToInt32(cmd.Parameters["@NewID"].Value);
                conn.Close();
            }
        }

        public void InsertCurriculumItem(int attackMethodFormID, int attackMethodsID, int standingMethodsID, int strategiesID, int turningMethodsID)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = this.ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.InsertCurriculumItems", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ParentCurriculumID", this.CurriculumID));
                cmd.Parameters.Add(new SqlParameter("@AttackMethodFormID", attackMethodFormID));
                cmd.Parameters.Add(new SqlParameter("@AttackMethodsID", attackMethodsID));
                cmd.Parameters.Add(new SqlParameter("@StandingMethodsID", standingMethodsID));
                cmd.Parameters.Add(new SqlParameter("@StrategiesID", strategiesID));
                cmd.Parameters.Add(new SqlParameter("@TurningMethodsID", turningMethodsID));

                cmd.ExecuteNonQuery();

                this.CurriculumID = Convert.ToInt32(cmd.Parameters["@NewID"].Value);
                conn.Close();
            }
        }
    }
}