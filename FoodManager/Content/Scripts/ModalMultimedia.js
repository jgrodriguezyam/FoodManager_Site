function createModalMultimedia(options) {
    //VARIABLES
    var multimedias = [];
    var isFirst = true;
    var carouselIndicators = [];
    var carouselImages = [];
    var carouselVideos = [];
    var modalTemplate = [];
    var title = 'Multimedia';

    //OPTIONS
    if (options.Multimedias) multimedias = options.Multimedias;
    if (options.Title) title = options.Title;

    //INSTANCE
    $(multimedias).each(function (index, multimedia) {
        if (multimedia.IsImage) {
            setCarouselIndicators(index);
            setCarouseImages(multimedia);
        }
        if (multimedia.IsVideo) {
            setCarouselIndicators(index);
            setCarouseVideos(multimedia);
        }
        isFirst = false;
    });

    setModalTemplate();
    showModalTemplate();
    createCarrousel();

    clearOpacity();

    //INTERNAL
    function setCarouselIndicators(index) {
        carouselIndicators.push('<li data-target="#ModalCarousel" data-slide-to="' + index + '" class="' + resolveClass() + '"');
        carouselIndicators.push('</li>');
    }

    function setCarouseImages(multimedia) {
        carouselImages.push('<div class="' + resolveClass() + ' item" style="text-align: center;">');
        carouselImages.push('<img src="' + multimedia.Source + '" style="max-height: 400px; margin: 0 auto; padding-bottom: 1px;" />');
        carouselImages.push('</div>');

    }

    function setCarouseVideos(multimedia) {
        carouselVideos.push('<div class="' + resolveClass() + ' item" style="text-align: center;">');
        carouselVideos.push('<video style="height:100%; width:100%;"controls src="' + multimedia.Path + '" type="video/mp4"></video>');
        carouselVideos.push('<div style="display:block;text-align:center; margin-top:3px;">');
        carouselVideos.push('</div>');
        carouselVideos.push('</div>');
    }

    function resolveClass() {
        return isFirst ? "active" : "";
    }

    function setModalTemplate() {
        if (carouselVideos.length > 0 || carouselImages.length > 0) {
            modalTemplate.push('<div id="ModalCarousel" class="carousel"  style="margin: -15px;">');
            modalTemplate.push('<ol class="carousel-indicators">');
            modalTemplate.push(carouselIndicators.join(''));
            modalTemplate.push('</ol>');
            modalTemplate.push('<div class="carousel-inner">');
            modalTemplate.push(carouselImages.join(''));
            modalTemplate.push(carouselVideos.join(''));
            modalTemplate.push('</div>');
            if (multimedias.length > 1) {
                modalTemplate.push('<a class="carousel-control left" href="#ModalCarousel" data-slide="prev"><i class="fa fa-chevron-left"></i></a>');
                modalTemplate.push('<a class="carousel-control right" href="#ModalCarousel" data-slide="next"><i class="fa fa-chevron-right"></i></a>');
            }
            modalTemplate.push('</div>');
        } else {
            modalTemplate.push('<div id="ModalCarousel" class="carousel  text-center">');
            modalTemplate.push('Sin contenido multimedia');
            modalTemplate.push('</div>');
        }
    }

    function showModalTemplate() {
        createDialog({
            Title: title,
            Message: modalTemplate.join('')
        });
    }

    function createCarrousel() {
        $("#ModalCarousel").carousel({
            interval: false,
            wrap: false
        });
        $("#ModalCarousel").carousel("pause");
    }

}

