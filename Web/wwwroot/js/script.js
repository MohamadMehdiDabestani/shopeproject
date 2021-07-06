$(document).ready(function () {
  function SubComment(id) {
    $([document.documentElement, document.body]).animate(
      {
        scrollTop: $("#comment").offset().top - 200,
      },
      2000
    );
    $("#ParentId").val(id);
  }
  
});
