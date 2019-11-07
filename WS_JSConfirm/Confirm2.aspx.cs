using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

public partial class Confirm2 : System.Web.UI.Page
{

    bool _isConfirmNeeded = true;
    string _confirmMessage = string.Empty;

    public bool IsConfirmNeeded
    {
        get { return _isConfirmNeeded; }
        set { _isConfirmNeeded = value; }
    }

    public string ConfirmMessage
    {
        get { return _confirmMessage; }
        set { _confirmMessage = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

        //Set Properties
        IsConfirmNeeded = true;
        ConfirmMessage = "Do you want to proceed ?";

        // Insure that the __doPostBack() JavaScript is added to the page...
        ClientScript.GetPostBackEventReference(this, string.Empty);

        if (IsPostBack)
        {
            string eventTarget = Request["__EVENTTARGET"] ?? string.Empty;
            string eventArgument = Request["__EVENTARGUMENT"] ?? string.Empty;

            switch (eventTarget)
            {
                case "UserConfirmationPostBack":
                    if (Convert.ToBoolean(eventArgument))
                    {
                        // User said to go ahead and do it...
                        Label1.Text = "Mensagem 01";
                    }
                    else
                    {
                        Label1.Text = "Mensagem 02";
                        // User said NOT to do it...
                    }
                    break;
            }
        }

    }

    protected void Button1_OnClick(object sender, EventArgs e)
    {
        if (IsConfirmNeeded)
        {
            StringBuilder javaScript = new StringBuilder();

            string scriptKey = "ConfirmationScript";

            javaScript.AppendFormat("var userConfirmation = window.confirm('{0}');\n", ConfirmMessage);

            // Un-comment to only PostBack if user answers OK...
            //javaScript.Append("if ( userConfirmation == true )\n");
            javaScript.Append("__doPostBack('UserConfirmationPostBack', userConfirmation);\n");

            ClientScript.RegisterStartupScript(GetType(), scriptKey, javaScript.ToString(), true);
        }
    }
}