using SourceCode.Workflow.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkDev.VehicleLicense.API.Services
{
    public class K2TaskService
    {



        public WorklistCriteria MapFromSourceToDestination(TasksSearchCriteria sourceEntity, string processName = null)
        {
            if (sourceEntity == null)
            {
                return null;
            }

            WorklistCriteria worklistCriteria = new WorklistCriteria();

            // Filter for (Available and Open ) Tasks /// 

            worklistCriteria.AddFilterField(WCLogical.StartBracket, WCField.None, WCCompare.Equal, null);

            worklistCriteria.AddFilterField(WCField.WorklistItemStatus, WCCompare.Equal, WorklistStatus.Available);
            worklistCriteria.AddFilterField(WCLogical.Or, WCField.WorklistItemStatus, WCCompare.Equal, WorklistStatus.Open);

            worklistCriteria.AddFilterField(WCLogical.EndBracket, WCField.None, WCCompare.Equal, null);

            ////////////////////////////////////////////


            if (sourceEntity.RequestNumbers.Any())
            {
                worklistCriteria.AddFilterField(WCLogical.StartBracket, WCField.None, WCCompare.Equal, null);

                foreach (var number in sourceEntity.RequestNumbers)
                {
                    worklistCriteria.AddFilterField(WCLogical.Or, WCField.ProcessFolio, WCCompare.Equal, number);
                }

                worklistCriteria.AddFilterField(WCLogical.EndBracket, WCField.None, WCCompare.Equal, null);
            }

            #region Commented

            //if (!string.IsNullOrEmpty(sourceEntity.SearchKeyword))
            //{
            //    worklistCriteria.AddFilterField(WCLogical.And, WCField.None, WCCompare.Equal, null);

            //    worklistCriteria.AddFilterField(WCLogical.StartBracket, WCField.ProcessFolio, WCCompare.Like, string.Format("%{0}%", sourceEntity.SearchKeyword));

            //    foreach (var value in sourceEntity.AssignedDepartmentKeys)
            //    {
            //        worklistCriteria.AddFilterField(WCLogical.Or, WCField.ProcessData, Core.Constants.EServicesConstants.DataFields.AssignedDepartmentKey, WCCompare.Equal, value);
            //    }

            //    foreach (var value in sourceEntity.RequestStatusIds)
            //    {
            //        worklistCriteria.AddFilterField(WCLogical.Or, WCField.ProcessData, Core.Constants.EServicesConstants.DataFields.Status, WCCompare.Equal, value);
            //    }

            //    foreach (var value in sourceEntity.IssuingDepartmentKeys)
            //    {
            //        worklistCriteria.AddFilterField(WCLogical.Or, WCField.ProcessData, Core.Constants.EServicesConstants.DataFields.IssuingDepartmentKey, WCCompare.Equal, value);
            //    }

            //    foreach (var value in sourceEntity.ServiceTypeIds)
            //    {
            //        worklistCriteria.AddFilterField(WCLogical.Or, WCField.ProcessName, WCCompare.Equal, ProcessUtilities.GetProcessShortName((ServiceType)value));
            //    }

            //    worklistCriteria.AddFilterField(WCLogical.EndBracket, WCField.None, WCCompare.Equal, null);
            //}

            //if (sourceEntity.DateTo != null)
            //{
            //    worklistCriteria.AddFilterField(WCLogical.And, WCField.ProcessStartDate, WCCompare.LessOrEqual, sourceEntity.DateTo.ToDateTime());
            //}

            //if (sourceEntity.DateFrom != null)
            //{
            //    worklistCriteria.AddFilterField(WCLogical.And, WCField.ProcessStartDate, WCCompare.GreaterOrEqual, sourceEntity.DateFrom.ToDateTime());
            //}


            //if (!string.IsNullOrEmpty(sourceEntity.IssuingDepartment))
            //{
            //    if (sourceEntity.IssuingDepartmentKeys.Any())
            //    {
            //        worklistCriteria.AddFilterField(WCLogical.And, WCField.ProcessData, Core.Constants.EServicesConstants.DataFields.IssuingDepartmentKey, WCCompare.Equal, sourceEntity.IssuingDepartmentKeys.First());

            //        ////worklistCriteria.AddFilterField(WCLogical.StartBracket, WCField.None, WCCompare.Equal, null);

            //        ////foreach (var key in sourceEntity.IssuingDepartmentKeys)
            //        ////{
            //        ////    worklistCriteria.AddFilterField(WCLogical.Or, WCField.ProcessData, Core.Constants.EServicesConstants.DataFields.IssuingDepartmentKey, WCCompare.Equal, key);
            //        ////}

            //        ////worklistCriteria.AddFilterField(WCLogical.EndBracket, WCField.None, WCCompare.Equal, null);
            //    }
            //    else
            //    {
            //        worklistCriteria.AddFilterField(WCLogical.And, WCField.ProcessData, Core.Constants.EServicesConstants.DataFields.IssuingDepartmentKey, WCCompare.Equal, sourceEntity.IssuingDepartment);
            //    }
            //}

            #endregion

            if (!string.IsNullOrEmpty(sourceEntity.SerialNumber))
            {
                worklistCriteria.AddFilterField(WCLogical.And, WCField.ProcessFolio, WCCompare.Like, string.Format("%{0}%", sourceEntity.SerialNumber));
            }

            if (!string.IsNullOrEmpty(processName))
            {
                worklistCriteria.AddFilterField(WCLogical.And, WCField.ProcessName, WCCompare.Like, processName);
            }


            worklistCriteria.Count = 30;
            worklistCriteria.StartIndex = 0;

            var sortingField = MapField(sourceEntity.SortingField);

            worklistCriteria.AddSortField(sortingField, WCSortOrder.Ascending);

            //FillWorklistCriteriaSorting(sourceEntity, worklistCriteria);
            //FillWorklistCriteriaPaging(sourceEntity, worklistCriteria);
            return worklistCriteria;
        }

        private WCField MapField(string filterName)
        {
            WCField wcField;
            return Enum.TryParse(filterName, out wcField) ? wcField : throw new Exception("No WorklistFields mapped ");
        }
    }


    public class TasksSearchCriteria 
    {
        public string SearchKeyword { get; set; }

        public string SerialNumber { get; set; }

        public int? RequestStatus { get; set; }

        public string IssuingDepartment { get; set; }


        public List<int> RequestStatusIds { get; set; }

        public List<int> ServiceTypeIds { get; set; }

        public DateTime DateTo { get; set; }

        public DateTime DateFrom { get; set; }

        public IEnumerable<string> RequestNumbers { get; set; }

        public string SortingField { get; set; }
    }
}