<?php
    $uri = 'http://api.football-data.org/v2/teams/64';
    $reqPrefs['http']['method'] = 'GET';
    $reqPrefs['http']['header'] = 'X-Auth-Token: 48091dddf071411fb1bd2e2ecb1498a0';
    $stream_context = stream_context_create($reqPrefs);
    $response = file_get_contents($uri, false, $stream_context);
    $matches = json_decode($response);
    echo $matches->address;
?>