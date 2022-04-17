function thongke() {
    $('#Display').empty();
    var s = '<div class="container-fluid link" id="show"><div class="d-sm-flex align-items-center justify-content-between mb-4"> <h1 class="h3 mb-0 text-gray-800"> Thống Kê</h1 ><a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i class="fas fa-download fa-sm text-white-50"></i>Generate Report</a></div >'
    s +='<div class="row"><div class="col-5"><div class="col-10" id="user"></div><div class="col-10" id="phim"></div><div class="col-10" id="DangKy"></div></div>'
    s += '<div class="col-6" id="TopPhim"></div></div>'
    $('#Display').html(s);
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/NguoiDung',
        dataType: 'json',
        success: function (data) {
            var d = 0;
            $.each(data, function (key, val) {
                d++;
            });
            var str = '<div class="card border-left-primary shadow h-100 py-2" ><div class="card-body"><div class="row no-gutters align-items-center"><div class="col mr-2"> <div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Tài khoản</div><div class="h5 mb-0 font-weight-bold text-gray-800">' + d + '</div></div><div class="col-auto"> <i class="fas fa-user fa-2x text-gray-300"></i></div></div></div></div >';
            $('#user').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/MovieApi',
        dataType: 'json',
        success: function (data) {
            var d = 0;
            $.each(data, function (key, val) {
                d++;
            });
            var str = '<div class="card border-left-success shadow h-100 py-2"><div class="card-body" ><div class="row no-gutters align-items-center"><div class="col mr-2"><div class="text-xs font-weight-bold text-success text-uppercase mb-1">Phim</div><div class="h5 mb-0 font-weight-bold text-gray-800">' + d + '</div></div><div class="col-auto"><i class="fas fa-video fa-2x text-gray-300"></i></div></div></div ></div >';
            $('#phim').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }

    });
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/DangKy',
        dataType: 'json',
        success: function (data) {

            var str = '<div class="card border-left-warning shadow h-100 py-2"><div class="card-body" ><div class="row no-gutters align-items-center"><div class="col mr-2"><div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Lượt Gia Hạn Gói</div><div class="h5 mb-0 font-weight-bold text-gray-800">' + data + '</div></div><div class="col-auto"><i class="fas fa-heart fa-2x text-gray-300"></i></div></div></div ></div >';
            $('#DangKy').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/MovieApi/Top',
        dataType: 'json',
        success: function (data) {

            var str = '<div class="card shadow mb-4"><div class="card-header py-3" ><h6 class="m-0 font-weight-bold text-primary" style="text-align:center">Top 10 phim được xem nhiều nhất</h6></div ><div class="card-body">';
            $.each(data, function (key, val) {
                str += '<div class="p-3 border-bottom-dark " style="background-color:#394380 "><b><img src="/Images/Index/' + val.Image + '" style="width :50px; height:50px" alt="' + val.Image + '"/></b><b> ' + val.Name + ' </b><b style="float:right">' + val.Viewed + '</b></div >';
            });
            str += '</div></div ></div >';
            $('#TopPhim').html(str);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
}