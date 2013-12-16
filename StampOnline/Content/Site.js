if (typeof StampOnline == "undefined") StampOnline = {};

StampOnline.AllowDrop = function(ev) {
    ev.preventDefault();
}

StampOnline.Drag = function(ev) {
    ev.dataTransfer.setData("Text", ev.target.id);
}

StampOnline.Drop =  function(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("Text");
    ev.target.appendChild(document.getElementById(data));
    $("#dragMe").hide();
    $("#Graphic_Position").val(ev.target.id);
}

StampOnline.HAlignmentClick = function()
{
    $(".alignmentImage").click(function () {
        $("#Alignment").val($(this).attr("data-sel"));
        $(".alignmentImage").css("border", "none");
        $(this).css("border", "solid");
    });
};

StampOnline.VAlignmentClick = function () {
    $(".vAlignmentImage").click(function () {
        $("#VAlign").val($(this).attr("data-sel"));
        $(".vAlignmentImage").css("border", "none");
        $(this).css("border", "solid");
    });
};

StampOnline.BorderClick = function () {
    $(".borderImage").click(function () {
        $("#Border").val($(this).attr("data-sel"));
        $(".borderImage").css("border", "none");
        $(this).css("border", "solid");
    });
};

StampOnline.ColourClick = function () {
    $(".colorImage").click(function () {
        $("#PadColour").val($(this).attr("data-sel"));
        $(".colorImage").css("border", "none");
        $(this).css("border", "solid");
    });
};

StampOnline.BuildPLStyle = function (line) {
    var isBold = $("[name $= 'Bold']", line).attr("checked") == "checked";
    var isItalic = $("[name $= 'Italic']", line).attr("checked") == "checked";
    var isUnderlined = $("[name $= 'Underlined']", line).attr("checked") == "checked";

    var fontStyle = "'";
    if (isBold)
        fontStyle += "font-weight: bold";
    if (isItalic)
        fontStyle += ";font-style: italic";
    if (isUnderlined)
        fontStyle += ";text-decoration: underline";
    fontStyle += "'";

    var style = "style=" + fontStyle;
    return style;
}

StampOnline.BuildNewPreviewLine = function (line) {
    var text = $("[name $= 'Text']", line).val();
    var style = StampOnline.BuildPLStyle(line);
    var newLine = "<div " + style + ">" + text + "</div>";
    return newLine;
}

StampOnline.PlaceGraph = function () {
    var position = $("#Graphic_Position").val();
    var image = $("#graphicOrigin");
    if(image.attr("src"))
    {
        $("#" + position).html(image[0].outerHTML);
        image.attr("src", "");
        $("#dragMe").hide();
    }
}

StampOnline.BuildPreviewContent = function () {
    var table = $("table");
    var lines = $("tr", table);
    for (var i = 1; i < lines.length; i++)
    {
        var line = lines[i];
        var newLine = StampOnline.BuildNewPreviewLine(line);
        $("#line" + i).html(newLine); 
    }
    StampOnline.PlaceGraph();
}

StampOnline.ShowModal = function (url) {
    var sharedObject = {};
    if (window.showModalDialog) {
        var retValue = showModalDialog(url, sharedObject, "dialogWidth:600px; dialogHeight:400px;");
        if (retValue == undefined)
            retValue = returnValue;
        if (retValue) {
            $("#graphicOrigin").attr("src", retValue.src);
            $("#graphicOrigin").css("width", retValue.size + "%");
            $("#dragMe").show();
        }
    }
    else {
        var modal = window.open(url, null, "width=600,height=400,modal=yes,alwaysRaised=yes", null);
        modal.dialogArguments = sharedObject;
    }
    return false;
}
   
$(document).ready(function () {
    StampOnline.HAlignmentClick();
    StampOnline.VAlignmentClick();
    StampOnline.BorderClick();
    StampOnline.ColourClick();
    StampOnline.BuildPreviewContent();
    $("input").change(StampOnline.BuildPreviewContent);
});