
$(document)
    .ajaxStart(function () {
        $('#AjaxLoader').show();
    })
    .ajaxStop(function () {
        $('#AjaxLoader').hide();
    })
$(document).ready(function () {

    if ($('#k').text() == "Log Out") {
        $('#mylist').click(function () {
            alert("Bạn Đã Đăng Nhập");
        });
    }
    else {
        $('#mylist').click(function () {
            alert("Bạn Chưa Đăng Nhập");
        });
    }
    $.ajax({

        type: 'GET',
        url: 'https://localhost:44301/api/CategoryApi',
        dataType: 'json',
        success: function (data) {
            var str = '';
            $.each(data, function (key, val) {
                str += '<tr  class="dropdown-item"><td>  </td><td><a href="https://localhost:44301/Home/GetMovieByCategory?id=' + val.CategoryID + '">' + val.NameCategory + '</a></td><td>  </td></tr>';
            });

            $('#lstGenre').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
    $('#lstGenre').hide();
    $('#Genre').click(function () {
        $('#lstCountry').hide();
        $('#lstGenre').slideToggle();

    });

    $.ajax({

        type: 'GET',
        url: 'https://localhost:44301/api/CountryApi',
        dataType: 'json',
        success: function (data) {
            var str = '';
            $.each(data, function (key, val) {
                str += '<tr  class="dropdown-item"><td>  </td><td><a href="https://localhost:44301/Home/GetMovieByCountry?id=' + val.CountryID + '">' + val.Name + '</a></td><td>  </td></tr>';
            });

            $('#lstCountry').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
    $('#lstCountry').hide();
    $('#Country').click(function () {
        $('#lstGenre').hide();
        $('#lstCountry').slideToggle();
    });
})
