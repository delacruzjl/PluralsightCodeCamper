(function() {
    "use strict";
    var $tagDialog = $("#tagDialog");
    var $doc = $(document);

    $.getJSON("/api/tags",
        function(data) {

            var viewModel = {
                // data
                tags: ko.observableArray(ko.toProtectedObservableItemArray(data)),
                tagToAdd: ko.observable(""),
                selectedTag: ko.observable(null),

                // behaviors
                addTag: addTagClick,
                selectTag: selectTagClick,
                saveClick: saveClick,
                cancelClick: cancelClick
            };

            $doc.on(
                "click",
                ".btn-danger",
                removeItemClick);

            $doc.on(
                "click",
                ".btn-warning",
                editItemClick);

            ko.applyBindings(viewModel);

            //////

            function addTagClick() {
                this.tags.push({ Name: this.tagToAdd(), TimeStamp: new Date().toLocaleTimeString() });
                this.tagToAdd("");
            }

            function selectTagClick() {
                viewModel.selectedTag(this);
            }

            function removeItemClick() {
                var itemToRemove = ko.dataFor(this);
                viewModel.tags.remove(itemToRemove);
            }

            function editItemClick() {
                $tagDialog.modal("show");
            }

            function saveClick() {
                viewModel.selectedTag().commit();
                $tagDialog.modal("hide");
            }

            function cancelClick() {
                $tagDialog.modal("hide");
            }
        });
})();