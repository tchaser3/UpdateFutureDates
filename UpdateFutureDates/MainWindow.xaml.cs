/* Title:           Update Future Dates
 * Date:            1-8-19
 * Author:          Terry Holmes
 * 
 * Description:     This will allow the user to change the bulk dates */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewEventLogDLL;

namespace UpdateFutureDates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //setting up the classes
        WPFMessagesClass TheMessagesClass = new WPFMessagesClass();
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up the data
        FindFutureEmployeeProjectAssgnmentDataSet aFindFutureEmployeeProjectAssignmentDataSet;
        FindFutureEmployeeProjectAssgnmentDataSet TheFindFutureEmployeeProjectAssignmentDataSet;
        FindFutureEmployeeProjectAssgnmentDataSetTableAdapters.FindFutureEmployeeProjectAssignmentTableAdapter aFindFutureEmployeeProjectAssignmentTableAdapter;

        UpdateEmployeeProjectAssignmentDateEntryTableAdapters.QueriesTableAdapter aUpdateEmployeeProjectAssignmentDateTableAdapter;

        FindEmployeeCrewAssignmentFutureDatesDataSet aFindEmployeeCrewAssignmentFutureDatesDataSet;
        FindEmployeeCrewAssignmentFutureDatesDataSet TheFindEmployeeCrewAssignmentFutureDatesDataSet;
        FindEmployeeCrewAssignmentFutureDatesDataSetTableAdapters.FindEmployeeCrewAssignmentFutureDatesTableAdapter aFindEmployeeCrewAssignmentFutureDatesTableAdapter;

        UpdateEmployeeCrewAssignmentDateEntryTableAdapters.QueriesTableAdapter aUpdateEmployeeCrewAssignmentDateTableAdapter;

        FindProjectTaskFutureDatesDataSet aFindProjectTaskFutureDatesDataSet;
        FindProjectTaskFutureDatesDataSet TheFindProjectTaskFutureDatesDataSet;
        FindProjectTaskFutureDatesDataSetTableAdapters.FindProjectTaskFutureDatesTableAdapter aFindProjectTaskFutureDatesTableAdapter;

        UpdateProjectTaskDateEntryTableAdapters.QueriesTableAdapter aUpdateProjectTaskDateTableAdapter;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private FindEmployeeCrewAssignmentFutureDatesDataSet FindEmployeeCrewAssignmentFutureDates(DateTime datTransactionDate)
        {
            try
            {
                aFindEmployeeCrewAssignmentFutureDatesDataSet = new FindEmployeeCrewAssignmentFutureDatesDataSet();
                aFindEmployeeCrewAssignmentFutureDatesTableAdapter = new FindEmployeeCrewAssignmentFutureDatesDataSetTableAdapters.FindEmployeeCrewAssignmentFutureDatesTableAdapter();
                aFindEmployeeCrewAssignmentFutureDatesTableAdapter.Fill(aFindEmployeeCrewAssignmentFutureDatesDataSet.FindEmployeeCrewAssignmentFutureDates, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Update Future Dates //Find Employee Crew Assignment Future Dates " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            return aFindEmployeeCrewAssignmentFutureDatesDataSet;
        }
        private bool UpdateEmployeeCrewAssignmentDate(int intTransactionID, DateTime datTransactionDate)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateEmployeeCrewAssignmentDateTableAdapter = new UpdateEmployeeCrewAssignmentDateEntryTableAdapters.QueriesTableAdapter();
                aUpdateEmployeeCrewAssignmentDateTableAdapter.UpdateEmployeeCrewAssignmentDate(intTransactionID, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Update Future Dates // Update Employee Crew Assignment Date " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private FindProjectTaskFutureDatesDataSet FindProjectTaskFutureDates(DateTime datTransactionDate)
        {
            try
            {
                aFindProjectTaskFutureDatesDataSet = new FindProjectTaskFutureDatesDataSet();
                aFindProjectTaskFutureDatesTableAdapter = new FindProjectTaskFutureDatesDataSetTableAdapters.FindProjectTaskFutureDatesTableAdapter();
                aFindProjectTaskFutureDatesTableAdapter.Fill(aFindProjectTaskFutureDatesDataSet.FindProjectTaskFutureDates, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Update Future Dates // Find Project Task Future Dates " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            return aFindProjectTaskFutureDatesDataSet;
        }
        private bool UpdateProjectTaskDates(int intTransactionID, DateTime datTransactionDate)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateProjectTaskDateTableAdapter = new UpdateProjectTaskDateEntryTableAdapters.QueriesTableAdapter();
                aUpdateProjectTaskDateTableAdapter.UpdateProjectTaskDate(intTransactionID, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Update Future Dates // Update Project Task Dates " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());

                blnFatalError = true;
            }

            return blnFatalError;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime datTransactionDate = DateTime.Now;

            TheFindProjectTaskFutureDatesDataSet = FindProjectTaskFutureDates(datTransactionDate);

            dgrResults.ItemsSource = TheFindProjectTaskFutureDatesDataSet.FindProjectTaskFutureDates;
        }
        private FindFutureEmployeeProjectAssgnmentDataSet FindFutureEmployeeProjectAssignment(DateTime datTransactionDate)
        {
            try
            {
                aFindFutureEmployeeProjectAssignmentDataSet = new FindFutureEmployeeProjectAssgnmentDataSet();
                aFindFutureEmployeeProjectAssignmentTableAdapter = new FindFutureEmployeeProjectAssgnmentDataSetTableAdapters.FindFutureEmployeeProjectAssignmentTableAdapter();
                aFindFutureEmployeeProjectAssignmentTableAdapter.Fill(aFindFutureEmployeeProjectAssignmentDataSet.FindFutureEmployeeProjectAssignment, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Update Future Dates // Find Future Employee Project Assignments " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }

            return aFindFutureEmployeeProjectAssignmentDataSet;
        }
        private bool UpdateEmployeeProjectAssginmentDate(int intTransactionID, DateTime datTransactionDate)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateEmployeeProjectAssignmentDateTableAdapter = new UpdateEmployeeProjectAssignmentDateEntryTableAdapters.QueriesTableAdapter();
                aUpdateEmployeeProjectAssignmentDateTableAdapter.UpdateEmployeeProjectAssignmentDate(intTransactionID, datTransactionDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Update Future Dates // Update Employee Project Assignment Date " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());

                blnFatalError = true;
            }

            return blnFatalError;
        }

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            int intCounter;
            int intNumberOfRecords;
            DateTime datTransactionDate;
            int intTransactionID;
            bool blnFatalError = false;

            try
            {
                intNumberOfRecords = TheFindProjectTaskFutureDatesDataSet.FindProjectTaskFutureDates.Rows.Count - 1;

                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    intTransactionID = TheFindProjectTaskFutureDatesDataSet.FindProjectTaskFutureDates[intCounter].TransactionID;
                    datTransactionDate = TheFindProjectTaskFutureDatesDataSet.FindProjectTaskFutureDates[intCounter].TransactionDate;

                    datTransactionDate = new DateTime(2018, datTransactionDate.Month, datTransactionDate.Day);

                    blnFatalError = UpdateProjectTaskDates(intTransactionID, datTransactionDate);

                    if (blnFatalError == true)
                        throw new Exception();
                }

                TheMessagesClass.InformationMessage("Process Complete");
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Update Future Dates // Process Button " + Ex.Message);

                TheMessagesClass.ErrorMessage(Ex.ToString());
            }
        }
    }
}
