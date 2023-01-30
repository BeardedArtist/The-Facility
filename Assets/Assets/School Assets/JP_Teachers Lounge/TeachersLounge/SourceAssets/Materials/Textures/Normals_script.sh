 for i in *Normal*.png; do 
    echo "$i"
    magick convert "$i" -channel G -negate "$i"
 done