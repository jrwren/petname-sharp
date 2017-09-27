#!/bin/sh

function camel() {
  echo $* |  sed -r 's/(^|_)([a-z])/\U\2/g'
}

TARGET=Petnames/Words_generated.cs
cat > $TARGET << EOF
//  Words_generated.cs
//
//  Created by Jay Wren on 10/22/17.
//  Copyright © 2017 Jay Wren. All rights reserved.
//
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Petnames
{
	public static partial class Words
	{
EOF

{
for i in $(find petname/ -type f) ; do
    size=$(basename $(dirname $i))
    part=$(basename $i .txt)
    prop=$(camel $size)$(camel $part)
    echo "\t\tpublic static ReadOnlyCollection<string> $prop => new ReadOnlyCollection<string>(${size}_$part);\n"
    echo "\t\tpublic static List<string> ${size}_$part = new List<string>(new[] {"
    awk '{print "\t\t\t\""$0"\","}' $i
    echo "\t\t});\n"
done
} >> $TARGET

cat >> $TARGET << EOF
	}
}
EOF
