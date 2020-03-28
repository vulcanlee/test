window.fileUpload=function (inputFile) {

    return readUploadedFileAsText(inputFile);
};
const readUploadedFileAsText = (inputFile) => {
    // https://developer.mozilla.org/zh-TW/docs/Web/API/FileReader
    const temporaryFileReader = new FileReader();
    // https://developer.mozilla.org/zh-TW/docs/Web/JavaScript/Reference/Global_Objects/Promise
    return new Promise((resolve, reject) => {
        temporaryFileReader.onerror = () => {
            temporaryFileReader.abort();
            reject(new DOMException("Problem parsing input file."));
        };
        temporaryFileReader.addEventListener("load", function () {
            var data = {
                content: temporaryFileReader.result.split(',')[1]
            };
            resolve(data);
        }, false);
        temporaryFileReader.readAsDataURL(inputFile.files[0]);
    });
};


