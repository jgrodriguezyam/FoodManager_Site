function createModalDetails(options) {
    //VARIABLES
    var title = "";
    var row = {};
    var objectToRead = "";
    var propertiesToRead = [];
    var isList = false;
    var modalTemplate = [];
    var tableBody = [];

    //OPTIONS
    if (options.Title) title = options.Title;
    if (options.ObjectToRead) objectToRead = options.ObjectToRead;
    if (options.Row) row = options.Row;
    if (options.PorpertiesToRead) propertiesToRead = options.PorpertiesToRead;
    if (options.IsList) isList = options.IsList;

    //INSTANCE
    if (isList) {
        $(row[objectToRead]).each(function(indexRow, element) {
            tableBody.push('<tr>');
            $(propertiesToRead).each(function(indexEmlement, property) {
                row = element;

                $(property.split('.')).each(function(index, propertySplit) {
                    extractValue(propertySplit, row);
                    row = row[propertySplit];
                });

                if (property == "Status") {
                    tableBody.push('<td style="width: 30px;">' + valueExtracted + '</td>');
                } else {
                    tableBody.push('<td class="detail">' + valueExtracted + '</td>');
                }
                
            });
            tableBody.push('</tr>');
        });
    } else {
        row = objectToRead != "" ? row[objectToRead] : row;
        $(propertiesToRead).each(function(indexEmlement, property) {
            var label = property.split(",")[0];
            var value = property.split(",")[1];
            extractValue(value, row);

            tableBody.push('<tr>');
            tableBody.push('<td class="detail" style="width: 150px;">' + label + '</td>');
            tableBody.push('<td class="detail value">' + valueExtracted + '</td>');
            tableBody.push('</tr>');
        });
    }

    setModalTemplate();
    showModalTemplate();

    //INTERNAL
    function setModalTemplate() {
        modalTemplate.push('<div class="table">');
        modalTemplate.push('<table class="table"><tbody>');
        if (tableBody.length > 0) {
            modalTemplate.push(tableBody.join(''));
        } else {
            modalTemplate.push('<div class="text-center">Sin registros</div>');
        }
        modalTemplate.push('</tbody></table>');
        modalTemplate.push('</div>');
    }

    function showModalTemplate() {
        createDialog({
            Title: title,
            Message: modalTemplate.join(''),
            WithScroll: true
        });
    }

}

