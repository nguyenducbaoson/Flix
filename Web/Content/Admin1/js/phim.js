function phim() {
    $('#Display').empty();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/MovieApi',
        dataType: 'json',
        success: function (data) {
            var str = '<div class="row"><div class="col-10"><h1 class="h3 mb-2 text-gray-800">Danh sách phim</h1></div><div class="col-2"><div style="float:right"><button type="button" class="btn btn-success" onclick="formthemphim()">Thêm</button></div></div></div><br /><div class="card shadow mb-4"><div class="card-body"><div class="table-responsive"><table class="table table-bordered" id="dataTable" width="100%" cellspacing="0"><thead><tr><th>Mã Phim</th><th>Tên Phim</th><th>Ảnh</th><th style="text-align: center">Chức năng</th></tr></thead><tbody>';
            $.each(data, function (key, val) {

                str += '<tr><td style="text-align: center">' + val.MovieID + '</td><td style="text-align: center"><p>' + val.Name + '</p></td><td style="text-align: center"><img src="/Images/Index/' + val.Image + '" style="width :80px; height:80px" alt="' + val.Image + '"/></td><td style="width: 14%; text-align: center"><a type="submit" onclick="formsuaphim(\'' + val.MovieID + '\')" class="btn btn-primary btn-icon-split"><span class="icon text-white-50"><i class="fas fa-edit"></i></span></a><a type="submit" onclick="xoaphim(\'' + val.MovieID + '\')" class="btn btn-danger btn-icon-split"><span class="icon text-white-50"><i class="fas fa-trash"></i></span></a></td></tr> ';
            });
            str += '</tbody></table></div></div></div>';
  /*          $('#Display').html(str);*/
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}
function formsuaphim(MovieID) {
    $('#Display').empty();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/MovieApi/' + MovieID,
        dataType: 'json',
        success: function (data) {
            var c = data;
            var str = '<div class="row"><div class="col-10" ><h1 class="h3 mb-2 text-gray-800">Sửa Phim</h1></div ></div >';
            str += '<fieldset><legend></legend><div class="row" style="border-radius: 10px"><div class="col-xl-3 col-md-4 col-sm-4" style="padding: 5px;"><img style = "height:340px;width:100%;" src = "/Images/Index/' + data.Image + '" id="anh"/><input style="padding-top: 5px" type="file" name="fileUpload" id= "test"></div><div class="col-xl-8 col-md-7 col-sm-7" style="padding-top: 10px"><div><b>Tên Phim </b><input id="ten" type="text" value="' + data.Name + '"> </div> <div><b>Nội dung</b><input id="Description" type="text" value="' + data.Description + '"></div> <div><b>Năm phát hành</b><input id="Year" type="number" value="' + data.Year + '"></div><div> <b>Thể loại</b></br><select id="Category" style="width:100%;height:50px"></select></div><div><b>Quốc gia</b></br><select id="Country" style="width:100%;height:50px"></select></div><div><b>Link Trailer</b><input id="Linktrailer" type="text" value="' + data.TrailerLink + '"></div><div><b>Link Phim</b><input id="LinkMovie" type="text" value="' + data.MovieLink + '"></div><div><b>Thời lượng</b><input id="Time" type="text" value="' + data.Time + '"> </div></div> </div> <div> <button type="submit" class="btn btn-success" id="but">Lưu Cập Nhập</button></div></fieldset>';
            str += '</tbody></table></div></div ></div > ';
            $('#Display').html(str);
            $.ajax({
                type: 'GET',
                url: 'https://localhost:44301/api/CategoryApi',
                dataType: 'json',
                success: function (data) {
                    var s = '';
                    $.each(data, function (key, val) {
                        if (val.CategoryID == c.CategoryID) {
                            s += '<option selected="selected" value="' + val.CategoryID + '">' + val.NameCategory + '</option>';
                        }
                        else {
                            s += '<option value="' + val.CategoryID + '">' + val.NameCategory + '</option>';
                        }

                    });
                    $('#Category').html(s);
                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
            $.ajax({
                type: 'GET',
                url: 'https://localhost:44301/api/CountryApi',
                dataType: 'json',
                success: function (data) {
                    var s = '';
                    $.each(data, function (key, val) {
                        if (val.CountryID == c.CountryID) {
                            s += '<option selected="selected" value="' + val.CountryID + '">' + val.Name + '</option>';
                        }
                        else {
                            s += '<option value="' + val.CountryID + '">' + val.Name + '</option>';
                        }

                    });
                    $('#Country').html(s);
                },
                error: function (xhr) {
                    alert(xhr.responseText);
                }
            });
            $('#test').change(function (e) {
                var fileName = e.target.files[0].name;
                var reader = new FileReader();
                reader.onload = function (e) {
                    // get loaded data and render thumbnail.
                    document.getElementById("anh").src = e.target.result;
                };
                // read the image file as a data URL.
                reader.readAsDataURL(this.files[0]);
            });
            $('#but').click(function () {
                $.ajax({
                    type: 'PUT',
                    url: 'https://localhost:44301/api/MovieApi/update?id=' + data.MovieID + '&name=' + $('#ten').val().toString() + '&image=' + $('#test').val().toString() + '&category=' + $('#Category').find(":selected").val() + '&time=' + $('#Time').val().toString() + '&linkmovie=' + $('#LinkMovie').val().toString() + '&linktrailer=' + $('#Linktrailer').val().toString() + '&year=' + $('#Year').val() + '&country=' + $('#Country').find(":selected").val() + '&description=' + $('#Description').val().toString(),
                    dataType: 'json',
                    success: function (data) {
                        if (data == false)
                            alert("Sửa Không Thành Công");
                        else {
                            alert("Sửa Thành Công");
                            $('#Display').ready(function () {
                                phim();
                            });
                        }
                    },
                    error: function (xhr) {
                        alert(xhr.responseText);
                    }
                });
            });
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}
function formthemphim() {
    $('#Display').empty();
    var str = '<div class="row"><div class="col-10" ><h1 class="h3 mb-2 text-gray-800">Thêm Phim</h1></div ></div >';
    str += '<fieldset><legend></legend><div class="row" style="border-radius: 10px"><div class="col-xl-3 col-md-4 col-sm-4" style="padding: 5px;"><img style = "height:340px;width:100%;" src = "" id="anh"/><input style="padding-top: 5px" type="file" name="fileUpload" id= "test"></div><div class="col-xl-8 col-md-7 col-sm-7" style="padding-top: 10px"><div><b>Mã Phim </b><input id="Ma" type="text" value=""> </div><div><b>Tên Phim </b><input id="ten" type="text" value=""> </div> <div><b>Nội dung</b><input id="Description" type="text" value=""></div> <div><b>Năm phát hành</b><input id="Year" type="number" value=""></div><div> <b>Thể loại</b></br><select id="Category" style="width:100%;height:50px"></select></div><div><b>Quốc gia</b></br><select id="Country" style="width:100%;height:50px"></select></div><div><b>Link Trailer</b><input id="Linktrailer" type="text" value=""></div><div><b>Link Phim</b><input id="LinkMovie" type="text" value=""></div><div><b>Thời lượng</b><input id="Time" type="text" value=""> </div></div> </div> <div> <button type="submit" class="btn btn-success" id="but">Thêm</button></div></fieldset>';
    str += '</tbody></table></div></div ></div > ';
    $('#Display').html(str);
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/CategoryApi',
        dataType: 'json',
        success: function (data) {
            var s = '';
            $.each(data, function (key, val) {
                s += '<option value="' + val.CategoryID + '">' + val.NameCategory + '</option>';
            });
            $('#Category').html(s);
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44301/api/CountryApi',
        dataType: 'json',
        success: function (data) {
            var s = '';
            $.each(data, function (key, val) {
                s += '<option value="' + val.CountryID + '">' + val.Name + '</option>';
            });
            $('#Country').html(s);
            
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });
    $('#test').change(function (e) {
        var fileName = e.target.files[0].name;
        var reader = new FileReader();
        reader.onload = function (e) {
            // get loaded data and render thumbnail.
            document.getElementById("anh").src = e.target.result;
        };
        // read the image file as a data URL.
        reader.readAsDataURL(this.files[0]);
    });
    $('#but').click(function () {
        const paramrs = {
            id: $('#Ma').val().toString(),
            name: $('#ten').val().toString(),
            image: $('#test').val().toString(),
            category: $('#Category').val(),
            time: $('#Time').val().toString(),
            linkmovie: $('#LinkMovie').val().toString(),
            linktrailer: $('#Linktrailer').val().toString(),
            year: $('#Year').val(),
            country: $('#Country').val(),
            description: $('#Description').val().toString()

        }
        const params2 = $('#Ma').val().toString() + '&name=' + $('#ten').val().toString() + '&image=' + $('#test').val().toString() + '&category=' + $('#Category').val() + '&time=' + $('#Time').val().toString() + '&linkmovie=' + $('#LinkMovie').val().toString() + '&linktrailer=' + $('#Linktrailer').val().toString() + '&year=' +
            $('#Year').val() + '&country=' + $('#Country').val() + '&description=' + $('#Description').val().toString();
        $.ajax({
            type: 'POST',
            url: 'https://localhost:44301/api/MovieApi/insert',
            data: {
                id: $('#Ma').val().toString(),
                name: $('#ten').val().toString(),
                image: $('#test').val().toString(),
                category: $('#Category').val(),
                time: $('#Time').val().toString(),
                linkmovie: $('#LinkMovie').val().toString(),
                linktrailer: $('#Linktrailer').val().toString(),
                year: $('#Year').val(),
                country: $('#Country').val(),
                description: $('#Description').val().toString()
            },
            dataType: 'json',
            success: function (data) {
                if (data == false)
                    alert("Thêm Không Thành Công");
                else {
                    alert("Thêm Thành Công");
                    $('#Display').ready(function () {
                        phim();
                    });
                }
            },
            error: function (xhr) {
                alert(xhr.responseText);
            }
        });
    });

}
function xoaphim(id) {
    $.ajax({
        type: 'DELETE',
        url: 'https://localhost:44301/api/MovieApi/delete?id=' + id,
        dataType: 'json',
        success: function (data) {
            if (data == false)
                alert("Xóa Không Thành Công");
            else {
                alert("Xóa Thành Công");
                $('#Display').ready(function () {
                    phim();
                });
            }
        },
        error: function (xhr) {
            alert(xhr.responseText);
        }
    });

}