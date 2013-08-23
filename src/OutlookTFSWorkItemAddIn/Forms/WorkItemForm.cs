using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Client;
using Microsoft.Office.Interop.Outlook;
using System.Net;
using System.Xml.Serialization;
using System.IO;

namespace OutlookAddIn2.Forms
{
    public partial class WorkItemForm : Form
    {



        // === TFS variables
        static NetworkCredential tfsCredential;
        IGroupSecurityService gss;
        static Uri tfsUri;
        static string tfsProjectName = "";

        public WorkItem workItem { get; set; }
        public Project project { get; set; }
        MailItem mailItem;

        private WorkItemStore _wiStore;

        public WorkItemForm(MailItem mailItem)
        {
            InitializeComponent();
            grpWorkItem.Enabled = false;
            txtTeamProject.ReadOnly = true;

            this.mailItem = mailItem;

            LoadDefaultTFSConnection();
        }



        private void FillControls()
        {

            var userLst = GetMemberList();
            cmbAssignedTo.Items.Clear();
            cmbAssignedTo.Text = string.Empty;
            foreach (var u in userLst)
            {
                cmbAssignedTo.Items.Add(u.DisplayName);
            }

            // Iterations
            cmbIteration.Items.Clear();
            cmbIteration.Text = string.Empty;
            foreach (Node node in project.IterationRootNodes)
            {
                cmbIteration.Items.Add(node.Path);
                foreach (Node item in node.ChildNodes)
                {
                    cmbIteration.Items.Add(item.Path);
                }
            }
            if (cmbIteration.Items.Count > 0)
                cmbIteration.SelectedIndex = 0;

            // Area Path
            cmbArea.Items.Clear();
            cmbArea.Text = string.Empty;
            foreach (Node area in project.AreaRootNodes)
            {
                cmbArea.Items.Add(area.Path);

                foreach (Node item in area.ChildNodes)
                {
                    cmbArea.Items.Add(item.Path);
                }
            }
            if (cmbArea.Items.Count > 0)
                cmbArea.SelectedIndex = 0;


            cmbWorkItemType.Items.Clear();
            cmbWorkItemType.Text = string.Empty;
            foreach (var witi in from WorkItemType item in project.WorkItemTypes
                                 select new WorkItemTypeItem(item))
            {
                cmbWorkItemType.Items.Add(witi);
            }



        }

        private bool ValidateWorkItem()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(cmbWorkItemType.Text))
            {
                isValid = false;
                errorProvider1.SetError(cmbWorkItemType, "cannot be empty");
            }
            else
            {
                errorProvider1.SetError(cmbWorkItemType, "");
            }
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                isValid = false;
                errorProvider1.SetError(txtTitle, "cannot be empty");
            }
            else
            {
                errorProvider1.SetError(txtTitle, "");
            }
            if (string.IsNullOrEmpty(cmbAssignedTo.Text))
            {
                isValid = false;
                errorProvider1.SetError(cmbAssignedTo, "cannot be empty");
            }
            else
            {
                errorProvider1.SetError(cmbAssignedTo, "");
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                isValid = false;
                errorProvider1.SetError(txtDescription, "cannot be empty");
            }
            else
            {
                errorProvider1.SetError(txtDescription, "");
            }

            return isValid;
        }

        private void LoadDefaultTFSConnection()
        {
            var setting = LoadTFSConnection();

            if (setting != null)
            {
                var uri = new Uri(setting.Collection);
                TfsTeamProjectCollection tpc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);
                tpc.EnsureAuthenticated();
                _wiStore = (WorkItemStore)tpc.GetService(typeof(WorkItemStore));
                gss = (IGroupSecurityService)tpc.GetService(typeof(IGroupSecurityService));

                project = _wiStore.Projects[setting.TeamProject];
            }

            InitProject();
        }

        private void InitProject()
        {
            if (project != null)
            {

                txtTeamProject.Text = project.Name;

                this.Text = string.Format("{0} - Create Work Item", project.Name);

                FillControls();

                FillFromEmail();

                grpWorkItem.Enabled = true;
            }
        }

        private void btnTeamProject_Click(object sender, EventArgs e)
        {
            TeamProjectPicker pp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false);
            pp.ShowDialog();

            if (pp.SelectedTeamProjectCollection != null)
            {
                TfsTeamProjectCollection tpc = pp.SelectedTeamProjectCollection;
                tpc.EnsureAuthenticated();
                _wiStore = (WorkItemStore)tpc.GetService(typeof(WorkItemStore));
                gss = (IGroupSecurityService)tpc.GetService(typeof(IGroupSecurityService));

                if (pp.SelectedProjects != null)
                {
                    project = _wiStore.Projects[pp.SelectedProjects[0].Name];

                    var setting = new TFSProjectSetting()
                    {
                        Collection = pp.SelectedTeamProjectCollection.Uri.ToString(),
                        TeamProject = project.Name
                    };

                    SaveTFSConnection(setting);
                }

            }

            InitProject();
        }

        private void FillFromEmail()
        {
            txtTitle.Text = mailItem.Subject;
            txtDescription.Text = mailItem.Body;
        }

        private void CreateWorkItem()
        {

            try
            {
                WorkItemType wiType = project.WorkItemTypes[cmbWorkItemType.SelectedItem.ToString().ToUpper()];
                // === Create a new workitem
                WorkItem workItem = new WorkItem(wiType);
                workItem.Title = txtTitle.Text;

                workItem["Description"] = txtDescription.Text;
                workItem["Assigned To"] = cmbAssignedTo.Text;

                workItem.AreaPath = cmbArea.Text;
                workItem.IterationPath = cmbIteration.Text;


                string resultString = "";
                var validateResults = workItem.Validate();
                foreach (var validateResult in validateResults)
                    resultString = resultString + validateResult.ToString() + "\n";

                workItem.Save();

                WorkItemCollection workItems = _wiStore.Query("Select * from WorkItems Where [System.Id] = " + workItem.Id);
                MessageBox.Show(string.Format("WorkItem {0} has been created successfully.", workItem.Id));

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Identity[] GetMemberList()
        {

            var list = new List<Identity>();

            Identity[] appGroups = gss.ListApplicationGroups(project.Uri.ToString());
            foreach (Identity group in appGroups)
            {
                Identity[] groupMembers = gss.ReadIdentities(SearchFactor.Sid, new string[] { group.Sid }, QueryMembership.Expanded);
                foreach (Identity member in groupMembers)
                {
                    Console.WriteLine(member.DisplayName);
                    if (member.Members != null)
                    {
                        foreach (string memberSid in member.Members)
                        {
                            Identity memberInfo = gss.ReadIdentity(SearchFactor.Sid, memberSid, QueryMembership.None);
                            list.Add(memberInfo);
                        }
                    }
                }
            }

            return list.Distinct().ToArray();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateWorkItem())
                CreateWorkItem();
        }


        private void SaveTFSConnection(TFSProjectSetting setting)
        {
            try
            {
                String appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                XmlSerializer serializer = new XmlSerializer(typeof(TFSProjectSetting));
                TextWriter tw = new StreamWriter(Path.Combine(appData, "OutlookTFSWorkItemAddIn.xml"));
                serializer.Serialize(tw, setting);
                tw.Close();
            }
            catch (System.Exception)
            {

            }

        }

        private TFSProjectSetting LoadTFSConnection()
        {
            try
            {
                String appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                TextReader tr = new StreamReader(Path.Combine(appData, "OutlookTFSWorkItemAddIn.xml"));
                XmlSerializer serializer = new XmlSerializer(typeof(TFSProjectSetting));
                TFSProjectSetting b = (TFSProjectSetting)serializer.Deserialize(tr);
                tr.Close();

                return b;
            }
            catch (System.Exception)
            {
                return null;
            }

        }
    }

    internal class WorkItemTypeItem
    {
        public WorkItemType WorkItemType { get; private set; }

        public WorkItemTypeItem(WorkItemType workItemType)
        {
            WorkItemType = workItemType;
        }

        public override string ToString()
        {
            return WorkItemType.Name;
        }
    }

    public class TFSProjectSetting
    {
        public string Collection { get; set; }
        public string TeamProject { get; set; }

    }
}
