function FindProxyForURL(url, host) {
    var local = 'PROXY 127.0.0.1:8888';
    var nginx = 'PROXY 10.16.13.18:8080';
    var autoproxy = 'PROXY 127.0.0.1:8844';

    var patterns = {
        'google': autoproxy,
        'gstatic': autoproxy,
        'wikipedia': autoproxy,
        'github.com$': autoproxy,
        'golang.org$': autoproxy
    };

    for (var regex in patterns) {
        if (host.match(regex)) {
            logstr = host + " match regex /" + regex + "/ using " + patterns[regex];
            console.log(logstr);
            return patterns[regex];
        }
    }

    return 'DIRECT';
}
