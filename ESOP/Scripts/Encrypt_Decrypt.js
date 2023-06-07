function ValidateForm(caseid, URLlink) {
    var Txt_CaseId = caseid.split(","); 
   
    debugger;
    $.ajax(
        {
            type: "POST",
            url: "EncryptDecrypt.aspx/EncryptCaseID",
            data: "{UserName: '" + Txt_CaseId[0] + "',EmpID: '" + Txt_CaseId[1] + "',Constring: '" + Txt_CaseId[2] + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccess,
            failure: function (AjaxResponse) {
                return false;
            }
        }
          );

    function onSuccess(AjaxResponse) {       
        window.open(URLlink + AjaxResponse.d);
        return true;
    }
};