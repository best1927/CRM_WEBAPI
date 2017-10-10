jQuery.fn.dataTableExt.oApi.fnSetFilteringEnterPress = function (oSettings) {
    var _that = this;

    this.each(function (i) {
        $.fn.dataTableExt.iApiIndex = i;
        var
            $this = this,
            oTimerId = null,
            sPreviousSearch = null,
            anControl = $('input', _that.fnSettings().aanFeatures.f);

        anControl
          .unbind('keyup')
          .bind('keyup', function (e) {
              //if (anControl.val().length > 1 && e.keyCode == 13) {
              //    _that.fnFilter(anControl.val());
              //}
              if (e.keyCode == 13) {
                  _that.fnFilter(anControl.val());
              }
          });

        return this;
    });
    return this;
}