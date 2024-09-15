$(document).ready(function () {
    "use strict"; // start of use strict

    //==============================
    //menu
    //==============================
    $('.header__btn').on('click', function () {
        $(this).toggleclass('header__btn--active');
        $('.header').toggleclass('header--active');
        $('.sidebar').toggleclass('sidebar--active');
    });

    //==============================
    //filter
    //==============================
    $('.filter__item-menu li').each(function () {
        $(this).attr('data-value', $(this).text().tolowercase());
    });

    $('.filter__item-menu li').on('click', function () {
        var text = $(this).text();
        var item = $(this);
        var id = item.closest('.filter').attr('id');
        $('#' + id).find('.filter__item-btn input').val(text);
    });

    //==============================
    //tabs
    //==============================
    $('.profile__mobile-tabs-menu li').each(function () {
        $(this).attr('data-value', $(this).text().tolowercase());
    });

    $('.profile__mobile-tabs-menu li').on('click', function () {
        var text = $(this).text();
        var item = $(this);
        var id = item.closest('.profile__mobile-tabs').attr('id');
        $('#' + id).find('.profile__mobile-tabs-btn input').val(text);
    });

    //==============================
    //modal
    //==============================
    $('.open-modal').magnificpopup({
        fixedcontentpos: true,
        fixedbgpos: true,
        overflowy: 'auto',
        type: 'inline',
        preloader: false,
        focus: '#username',
        modal: false,
        removaldelay: 300,
        mainclass: 'my-mfp-zoom-in',
    });

    $('.modal__btn--dismiss').on('click', function (e) {
        e.preventdefault();
        $.magnificpopup.close();
    });

    //  ==============================
    // select2
    //  ==============================
    $('#quality').select2({
        placeholder: "choose quality",
        allowclear: true
    });

    $('#country').select2({
        placeholder: "choose country / countries"
    });

    $('#actor').select2({
        placeholder: "choose genre1111111 / genres"
    });

    $('#actor').select2({
        placeholder: "choose actor / actors"
    });

    $('#subscription, #rights').select2();

    //==============================
    //  upload cover
    //==============================
    function readurl(input) {
        if (input.files && input.files[0]) {
            var reader = new filereader();

            reader.onload = function (e) {
                $('#form__img').attr('src', e.target.result);
            }

            reader.readasdataurl(input.files[0]);
        }
    }

    $('#form__img-upload').on('change', function () {
        readurl(this);
    });

    /* ==============================*/
    // upload video
    /*  ==============================*/
    // Delegate event handling for dynamically added elements
    $(document).on('change', '.form__video-upload', function () {
        var videolabel = $(this).attr('data-name');

        if ($(this).val() != '') {
            $(videolabel).text($(this)[0].files[0].name);
        } else {
            $(videolabel).text('upload video');
        }
    });
    //==============================
    //   upload gallery
    //==============================
    $(document).on('change', '.form__video-upload', function () {
        var videolabel = $(this).attr('data-name');
        var filename = $(this)[0].files.length > 0 ? $(this)[0].files[0].name : 'upload video';

        console.log('Data-name:', videolabel);
        console.log('File name:', $(this)[0].files.length > 0 ? $(this)[0].files[0].name : 'upload video');


        $(videolabel).text(filename);
    });

    //==============================
    //scrollbar
    //==============================
    var scrollbar = window.scrollbar;

    if ($('.sidebar__nav').length) {
        scrollbar.init(document.queryselector('.sidebar__nav'), {
            damping: 0.1,
            renderbypixels: true,
            alwaysshowtracks: true,
            continuousscrolling: true
        });
    }

    if ($('.dashbox__table-wrap--1').length) {
        scrollbar.init(document.queryselector('.dashbox__table-wrap--1'), {
            damping: 0.1,
            renderbypixels: true,
            alwaysshowtracks: true,
            continuousscrolling: true
        });
    }

    if ($('.dashbox__table-wrap--2').length) {
        scrollbar.init(document.queryselector('.dashbox__table-wrap--2'), {
            damping: 0.1,
            renderbypixels: true,
            alwaysshowtracks: true,
            continuousscrolling: true
        });
    }

    if ($('.dashbox__table-wrap--3').length) {
        scrollbar.init(document.queryselector('.dashbox__table-wrap--3'), {
            damping: 0.1,
            renderbypixels: true,
            alwaysshowtracks: true,
            continuousscrolling: true
        });
    }

    if ($('.dashbox__table-wrap--4').length) {
        scrollbar.init(document.queryselector('.dashbox__table-wrap--4'), {
            damping: 0.1,
            renderbypixels: true,
            alwaysshowtracks: true,
            continuousscrolling: true
        });
    }

    if ($('.main__table-wrap').length) {
        scrollbar.init(document.queryselector('.main__table-wrap'), {
            damping: 0.1,
            renderbypixels: true,
            alwaysshowtracks: true,
            continuousscrolling: true
        });
    }

    //==============================
    //bg
    //==============================
    //$('.section--bg').each(function () {
    //    if ($(this).attr("data-bg")) {
    //            Console.log("'url(../' + $(this).data('bg') + ')'");
    //        $(this).css({
    //            'background': 'url(../' + $(this).data('bg') + ')',
    //            //   url(../ images / bg.jpg)
    //            'background-position': 'center center',
    //            'background-repeat': 'no-repeat',
    //            'background-size': 'cover'
    //        });
    //    }
    //});
    $('.section--bg').each(function () {
        var bg = $(this).data('bg');  // Get the data-bg attribute value
        if (bg) {
            console.log("url(../" + bg + ")");  // Log the constructed URL

            // Apply the background style to the element
            $(this).css({
                'background': 'url(../' + bg + ')',
                'background-position': 'center center',
                'background-repeat': 'no-repeat',
                'background-size': 'cover'
            });
        }
    });
    //==============================
    //avatar
    //==============================

    window.setTimeout(function () {
        //  Fade out the alert
        $('#myAlert').fadeTo(500, 0).slideUp(500, function () {
            $(this).remove();
        });
    }, 3000);



});

//const displayEpisodies = function () {
//    // Select the container where you want to insert the episodes
//    const containerEpisodes = document.querySelector('.Season__Episodies');

//    // Set up the blur event listener to capture input value and update the DOM
//    document.querySelector('.episodies__num').addEventListener('blur', function () {
//        // Get the value after the user leaves the input field
//        const inputValue = this.value;

//        // Clear the container before adding new content
//        containerEpisodes.innerHTML = '';

//        // Loop to generate HTML based on the user input
//        for (let i = 0; i < inputValue; i++) {
//            const html = `
//                <div class="sign__episode">
//                    <div class="row">
//                        <div class="col-12">
//                            <span class="sign__episode-title text-white">Episode #${i + 1}</span>
//                            <button class="sign__delete" type="button">
//                                <i class="fa-solid fa-user text-white"></i>
//                            </button>
//                        </div>

//                        <div class="col-12 col-lg-6">
//                            <div class="form__group">
//                                <input type="text" class="form__input" placeholder="Title">
//                            </div>
//                        </div>

//                        <div class="col-12 col-lg-6">
//                            <div class="form__group">
//                                <input type="number" class="form__input" placeholder="Duration">
//                            </div>
//                        </div>

//                        <div class="col-12">
//                            <div class="form__video">
//                                <label id="E${i + 1}" for="form__video-upload${i + 1}">Upload episode ${i + 1}</label>
//                                <input data-name="#E${i + 1} "asp-for="@Model.Episodes" id="form__video-upload${i + 1}" class="form__video-upload" type="file">
//                                <span class="text-danger"></span>
//                            </div>
//                        </div>
//                    </div>
//                </div>
//            `;

//            // Insert the generated HTML into the container
//            containerEpisodes.insertAdjacentHTML('beforeend', html);
//        }
//    });
//};

//// Call the function to set up the event listener
//displayEpisodies();
