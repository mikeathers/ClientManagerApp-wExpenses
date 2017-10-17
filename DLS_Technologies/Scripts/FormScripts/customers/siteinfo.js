
var token = $('input[name="__RequestVerificationToken"]').val();
$.ajaxPrefilter(function (options, originalOptions) {
    if (options.type.toUpperCase() == "PUT") {
        options.data = $.param($.extend(originalOptions.data, { __RequestVerificationToken: token }));
    }
});

function LoadSiteInfoNotesTable() {
    var custId = $("#CustomerId").val();
    var noteId = $("#NoteId").val();

    $.ajax({
        method: "GET",
        url: "/Customers/LoadSiteInfoNotesTable/",
        data: {
            id: custId,
            noteId: noteId
        },
    }).done(function (result) {
        $("#SiteInfoNotesTable").empty();
        $("#SiteInfoNotesTable").html(result);
    });
}

$(document).ready(function () {

    LoadSiteInfoNotesTable();

    $("#network-tab").parent().addClass("active");

    $("#edit-tab-btn").on("click", function (e) {
        e.preventDefault();
        $(this).parent().prev().find(".active").find("textarea").removeAttr("readonly").focus();
    });

    $("#save-tab-btn").on("click", function (e) {
        e.preventDefault();
        $(".nav-tabs").next().find("textarea").attr("readonly", "true");
        var note = $(this).parent().prev().find(".active").find("textarea").val();
        var noteType = $(this).parent().prev().find(".active").find("textarea").parent().attr("data-note-type");
        var custId = $(this).attr("data-customer-id");

        $.ajax({
            method: "PUT",
            url: "/Customers/SaveSiteInfoTabNote/",
            data: {
                note: note,
                noteType: noteType,
                id: custId
            },
            success: function () {
                toastr.success("Note Added!", "Success");
            }

        })
    });

    $(".nav-tabs").on("click", function () {
        $(this).next().find("textarea").attr("readonly", "true");
    });

    $("#save-note-btn").on("click", function (e) {

        e.preventDefault();
        var title = $("#NoteTitle").val();
        var content = $("#NoteContent").val();
        var custId = $(this).attr("data-customer-id");
        var noteId = $("#NoteId").val();

        if (title == "" || content == "") {
            $("#note-warning").html("Title and Content must be filled out before you can save a note.").show();
        } else {
            $.ajax({
                method: "PUT",
                url: "/Customers/SaveSiteInfoNote/",
                data: {
                    id: custId,
                    noteId: noteId,
                    noteTitle: title,
                    noteContent: content
                },
                success: function (result) {
                    $("#note-warning").hide();
                    $("#NoteId").val(result);
                    $("#NoteTitle").attr("readonly", "true");
                    $("#NoteContent").attr("readonly", "true");
                    LoadSiteInfoNotesTable();
                    toastr.success("Note Added!", "Success");
                }
            })
        }
    });

    $("#addnew-note-btn").on("click", function (e) {
        e.preventDefault();
        $("#NoteTitle").val("").removeAttr("readonly");
        $("#NoteContent").val("").removeAttr("readonly");
        $("#NoteId").val(0);
        $("#NoteTitle").focus();
    });

    $("#edit-note-btn").on("click", function (e) {
        e.preventDefault();
        $("#NoteTitle").removeAttr("readonly");
        $("#NoteContent").removeAttr("readonly");
        $("#NoteContent").focus();
    });

    $("#delete-note-btn").on("click", function (e) {
        e.preventDefault();
        var id = $("#NoteId").val();
        bootbox.confirm("Are you sure you want to delete this note?", (result) => {
            if (result) {
                $.ajax({
                    method: "DELETE",
                    url: "/Api/Customers/DeleteNote/" + id,

                    success: function () {
                        $("#NoteId").val(0);
                        LoadSiteInfoNotesTable();
                        toastr.success("Note deleted!", "Success");
                    }
                });
            }
        })
    })
})