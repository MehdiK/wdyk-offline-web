App.showOfflineRecords = (function () {
    var init = function () {
        var key, contactRow, record, rowData;
        var $contactRowTemplate = $('#contactRowTemplate');
        var $contactsGrid = $('#contacts-grid');

        if ($contactsGrid.length == 0)
            return;

        for (i = 0; i < localStorage.length; i = i + 1) {
            key = localStorage.key(i);

            record = JSON.parse(localStorage.getItem(key));
            rowData = { 
                FullName: record.data.FullName, 
                PhoneNumber: record.data.PhoneNumber, 
                Address: record.data.Address,
                Id: record.id
            };
            contactRow = _.template($contactRowTemplate.html(), rowData);
            $contactsGrid.append(contactRow);
        }
    };

    return {
        init: init
    };
}());