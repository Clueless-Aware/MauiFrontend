window.Main = {
    start: () => {
        Fancybox.bind('[data-fancybox="gallery"]', {

            Images: {
                initialSize: "fit",
                Panzoom: {
                    maxScale: 5,
                },
            },

            Toolbar: {
                display: {
                    left: ["infobar"],
                    middle: [
                        "zoomIn",
                        "zoomOut",
                        "toggle1to1",
                        "rotateCCW",
                        "rotateCW",
                        "flipX",
                        "flipY",
                    ],
                    right: ["slideshow", "thumbs", "close"],
                },
            },

        });
    },
}