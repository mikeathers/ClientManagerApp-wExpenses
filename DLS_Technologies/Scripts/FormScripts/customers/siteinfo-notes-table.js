
function GetNote(noteId) {
    $.ajax({
        method: "GET",
        url: "/Customers/GetNoteContent/",
        data: {
            id: noteId
        },
        success: function (result) {
            if (result) {
                var title = result.title;
                var note = result.note;
                $("#NoteContent").empty();
                $("#NoteTitle").empty();
                $("#NoteContent").val(note);
                $("#NoteTitle").val(title);
            } else {
                console.log("error");
            }
        }
    });
}
if ($("#NoteId").val() != 0) {
    $("#siteinfo-notes-table tbody tr td:first").addClass("selected");
    var noteId = $("#NoteId").val();
    GetNote(noteId);
} else if ($("#siteinfo-notes-table tr").length > 0) {
    var noteId = $("#siteinfo-notes-table tbody tr td:first").attr("data-note-id");
    $("#NoteId").val(noteId);
    GetNote(noteId);
} else {
    $("#NoteTitle").val("");
    $("#NoteContent").val("");
}

$("#siteinfo-notes-table tbody tr").click(function () {
    $(this).children().addClass("selected").parent().siblings().children().removeClass("selected");
    var noteId = $(this).children().attr("data-note-id");
    $("#NoteTitle").val($(this).children().text());
    $("#NoteId").val(noteId);
    GetNote(noteId);
});
