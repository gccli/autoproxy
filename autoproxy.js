function FindProxyForURL(url, host) {
    var squid = 'PROXY 192.168.1.102:3128';
    var local = 'PROXY 127.0.0.1:8888';
    var autoproxy = ['PROXY 127.0.0.1:8000', 'PROXY 10.16.13.18:8080'];

    var patterns = {
        'google': autoproxy,
        'wikipedia', autoproxy,
        'github\.com$': autoproxy,
    };

    for (var regex in patterns) {
        if (host.match(regex)) {
            logstr = host + " match regex /" + regex + "/ using " + patterns[regex];
            alert(logstr);
            return patterns[regex];
        }
    }

    return 'DIRECT';
}
